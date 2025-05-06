using System;
using System.Collections.Concurrent;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class FTPServer
{
    private const int ControlPort = 21;
    private const int DataPort = 20;

    private static readonly ConcurrentDictionary<TcpClient, string> ClientDirectories = new();
    private static readonly ConcurrentDictionary<TcpClient, bool> ActiveClients = new();
    private static string RootDirectory = @"G:\Root";

    public static void Main()
    {
        TcpListener controlListener = new TcpListener(IPAddress.Any, ControlPort);
        controlListener.Start();
        Console.WriteLine($"FTP Server started on port {ControlPort}...");

        try
        {
            while (true)
            {
                TcpClient client = controlListener.AcceptTcpClient();
                ActiveClients.TryAdd(client, true);
                ClientDirectories[client] = RootDirectory;

                Console.WriteLine($"New client connected: {client.Client.RemoteEndPoint}");
                ThreadPool.QueueUserWorkItem(HandleClient, client);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Server error: {ex.Message}");
        }
        finally
        {
            controlListener.Stop();
            Console.WriteLine("Server stopped.");
        }
    }

    private static void HandleClient(object? state)
    {
        if (state is not TcpClient client) return;

        string currentDirectory = ClientDirectories[client];

        try
        {
            using (client)
            using (NetworkStream controlStream = client.GetStream())
            using (StreamReader reader = new StreamReader(controlStream, Encoding.ASCII))
            using (StreamWriter writer = new StreamWriter(controlStream, Encoding.ASCII) { AutoFlush = true })
            {
                writer.WriteLine("220 FTP Server Ready");

                string username = null;
                bool isAuthenticated = false;

                while (true)
                {
                    string command = reader.ReadLine();
                    if (command == null) break;

                    Console.WriteLine($"Received: {command}");

                    string[] parts = command.Split(' ', 2);
                    string cmd = parts[0].ToUpper();
                    string argument = parts.Length > 1 ? parts[1] : null;

                    switch (cmd)
                    {
                        case "USER":
                            username = argument;
                            writer.WriteLine("331 Username OK, need password.");
                            break;

                        case "PASS":
                            if (username == "std" && argument == "123")
                            {
                                isAuthenticated = true;
                                writer.WriteLine("230 Login successful.");
                            }
                            else
                            {
                                writer.WriteLine("530 Login incorrect.");
                            }
                            break;

                        case "LIST":
                            if (isAuthenticated)
                            {
                                writer.WriteLine("150 Directory listing:");
                                try
                                {
                                    foreach (string dir in Directory.GetDirectories(currentDirectory))
                                    {
                                        writer.WriteLine($"<DIR> {Path.GetFileName(dir)}");
                                    }
                                    foreach (string file in Directory.GetFiles(currentDirectory))
                                    {
                                        writer.WriteLine(Path.GetFileName(file));
                                    }
                                    writer.WriteLine("226 Directory send OK.");
                                }
                                catch (Exception ex)
                                {
                                    writer.WriteLine($"450 Error listing directory: {ex.Message}");
                                }
                            }
                            else writer.WriteLine("530 Not logged in.");
                            break;

                        case "CWD":
                            if (isAuthenticated && argument != null)
                            {
                                string newPath = Path.Combine(currentDirectory, argument);
                                if (Directory.Exists(newPath))
                                {
                                    currentDirectory = newPath;
                                    ClientDirectories[client] = currentDirectory;
                                    writer.WriteLine($"250 Changed directory to {newPath}");
                                }
                                else writer.WriteLine("550 Directory not found.");
                            }
                            else writer.WriteLine("530 Not logged in.");
                            break;

                        case "RETR":
                            if (isAuthenticated && argument != null)
                            {
                                SendFile(argument, currentDirectory, writer);
                            }
                            else writer.WriteLine("530 Not logged in.");
                            break;

                        case "STOR":
                            if (isAuthenticated && argument != null)
                            {
                                ReceiveFile(argument, currentDirectory, writer);
                            }
                            else writer.WriteLine("530 Not logged in.");
                            break;

                        case "EXIT":
                            writer.WriteLine("221 Goodbye.");
                            return;

                        default:
                            writer.WriteLine("502 Command not implemented.");
                            break;
                    }
                }
            }
        }
        finally
        {
            ActiveClients.TryRemove(client, out _);
            ClientDirectories.TryRemove(client, out _);
            Console.WriteLine($"Client disconnected: {client.Client?.RemoteEndPoint}");
        }
    }

    private static void SendFile(string filename, string currentDirectory, StreamWriter writer)
    {
        string filePath = Path.GetFullPath(Path.Combine(currentDirectory, filename));

        if (!File.Exists(filePath))
        {
            writer.WriteLine("550 File not found.");
            return;
        }

        writer.WriteLine("150 Opening data connection.");

        TcpListener dataListener = new TcpListener(IPAddress.Any, DataPort);
        dataListener.Start();

        try
        {
            using (TcpClient dataClient = dataListener.AcceptTcpClient())
            using (NetworkStream dataStream = dataClient.GetStream())
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                byte[] buffer = new byte[8192];
                int bytesRead;

                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    dataStream.Write(buffer, 0, bytesRead);
                }

                dataStream.Flush();
            }

            writer.WriteLine("226 Transfer complete.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error sending file: {ex.Message}");
            writer.WriteLine("425 Error during transfer.");
        }
        finally
        {
            dataListener.Stop();
        }
    }

    private static void ReceiveFile(string filename, string currentDirectory, StreamWriter writer)
    {
        string filePath = Path.Combine(currentDirectory, filename);

        writer.WriteLine("150 Ready to receive file.");

        TcpListener dataListener = null;
        try
        {
            dataListener = new TcpListener(IPAddress.Any, DataPort);
            dataListener.Start();

            DateTime timeoutTime = DateTime.Now.AddSeconds(30);
            while (!dataListener.Pending() && DateTime.Now < timeoutTime)
            {
                Thread.Sleep(100);
            }

            if (!dataListener.Pending())
            {
                writer.WriteLine("425 Connection timed out.");
                return;
            }

            using (TcpClient dataClient = dataListener.AcceptTcpClient())
            using (NetworkStream dataStream = dataClient.GetStream())
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                byte[] buffer = new byte[8192];
                int bytesRead;

                while ((bytesRead = dataStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    fs.Write(buffer, 0, bytesRead);
                }
            }

            writer.WriteLine("226 File upload successful.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error receiving file: {ex.Message}");
            writer.WriteLine("425 Error during file transfer.");
        }
        finally
        {
            dataListener?.Stop();
        }
    }
}
