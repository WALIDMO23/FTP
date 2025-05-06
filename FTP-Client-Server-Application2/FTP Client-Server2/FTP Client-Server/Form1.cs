using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FTP_Client_Application
{
    public partial class Form1 : Form
    {
        private string _serverIp;
        private StreamReader _controlReader;
        private StreamWriter _controlWriter;

        public Form1()
        {
            InitializeComponent();

            btnConnect.Click += BtnConnect_Click;
            btnList.Click += BtnList_Click;
            btnDownload.Click += BtnDownload_Click;
            btnUpload.Click += BtnUpload_Click;
            btnExit.Click += (s, e) => Application.Exit();
            btnCWD.Click += BtnOpenFolder_Click;
            btnBack.Click += BtnBack_Click; // Add event handler for btnBack

            lbFiles.SelectedIndexChanged += LbFiles_SelectedIndexChanged;
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            _serverIp = txtServerIP.Text.Trim();
            if (string.IsNullOrWhiteSpace(_serverIp))
            {
                _serverIp = "127.0.0.1";
                lblStatus.Text = $"No IP provided; using default {_serverIp}";
            }
            else
            {
                lblStatus.Text = $"Connecting to {_serverIp}…";
            }

            try
            {
                var client = new TcpClient(_serverIp, 21);
                var controlStream = client.GetStream();
                _controlReader = new StreamReader(controlStream, Encoding.ASCII);
                _controlWriter = new StreamWriter(controlStream, Encoding.ASCII) { AutoFlush = true };

                lblStatus.Text = _controlReader.ReadLine();

                string user = txtUsername.Text.Trim();
                _controlWriter.WriteLine($"USER {user}");
                lblStatus.Text = _controlReader.ReadLine();

                string pass = txtPassword.Text;
                _controlWriter.WriteLine($"PASS {pass}");
                lblStatus.Text = _controlReader.ReadLine();

                lblStatus.Text = "Connected and authenticated.";
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Error: {ex.Message}";
            }
        }

        private void BtnList_Click(object sender, EventArgs e)
        {
            try
            {
                _controlWriter.WriteLine("LIST");
                string response = _controlReader.ReadLine();
                lblStatus.Text = response;

                if (response.StartsWith("150"))
                {
                    lbFiles.Items.Clear();
                    lbFolders.Items.Clear();
                    string line;
                    while ((line = _controlReader.ReadLine()) != null && !line.StartsWith("226"))
                    {
                        Console.WriteLine(line);

                        if (line.StartsWith("<DIR>"))
                        {
                            lbFolders.Items.Add(line.Substring(5).Trim());
                        }
                        else
                        {
                            lbFiles.Items.Add(line.Trim());
                        }
                    }
                    lblStatus.Text = "Directory listing complete.";
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"List error: {ex.Message}";
            }
        }

        private void BtnDownload_Click(object sender, EventArgs e)
        {
            string filename = SelectedItem(lbFiles);
            if (string.IsNullOrEmpty(filename))
            {
                lblStatus.Text = "Please select a file to download.";
                return;
            }

            try
            {
                _controlWriter.WriteLine($"RETR {filename}");
                string response = _controlReader.ReadLine();
                lblStatus.Text = response;

                if (response.StartsWith("150"))
                {
                    ReceiveFile(_serverIp, filename);
                    lblStatus.Text = _controlReader.ReadLine();
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Download error: {ex.Message}";
            }
        }

        private void BtnUpload_Click(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog())
            {
                if (dlg.ShowDialog() != DialogResult.OK)
                {
                    lblStatus.Text = "No file selected for upload.";
                    return;
                }

                string filename = dlg.FileName;

                try
                {
                    _controlWriter.WriteLine($"STOR {Path.GetFileName(filename)}");
                    string response = _controlReader.ReadLine();
                    lblStatus.Text = response;

                    if (response.StartsWith("150"))
                    {
                        Thread.Sleep(500);
                        SendFile(_serverIp, filename);
                        lblStatus.Text = _controlReader.ReadLine();
                    }
                }
                catch (Exception ex)
                {
                    lblStatus.Text = $"Upload error: {ex.Message}";
                }
            }
        }

        private void BtnOpenFolder_Click(object sender, EventArgs e)
        {
            string selectedFolder = SelectedItem(lbFolders);
            if (string.IsNullOrEmpty(selectedFolder))
            {
                lblStatus.Text = "Please select a folder to open.";
                return;
            }

            try
            {
                _controlWriter.WriteLine($"CWD {selectedFolder}");
                string response = _controlReader.ReadLine();
                lblStatus.Text = response;

                if (response.StartsWith("250"))
                {
                    lblStatus.Text = $"Changed directory to {selectedFolder}.";
                    BtnList_Click(sender, e);
                }
                else
                {
                    lblStatus.Text = "Failed to change directory.";
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Error changing directory: {ex.Message}";
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            try
            {
                // Send the CWD command with ".." to navigate to the parent directory
                _controlWriter.WriteLine("CWD ..");
                string response = _controlReader.ReadLine();
                lblStatus.Text = response;

                if (response.StartsWith("250"))
                {
                    lblStatus.Text = "Moved to parent directory.";
                    BtnList_Click(sender, e); // Refresh the directory listing
                }
                else
                {
                    lblStatus.Text = "Failed to move to parent directory.";
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Error moving to parent directory: {ex.Message}";
            }
        }

        private string SelectedItem(ListBox lb) =>
            lb.SelectedItem?.ToString();

        private void ReceiveFile(string serverIp, string filename)
        {
            try
            {
                using (var dlg = new SaveFileDialog { FileName = filename })
                {
                    if (dlg.ShowDialog() != DialogResult.OK)
                        return;

                    Thread.Sleep(500);

                    using (var dataClient = new TcpClient(serverIp, 20))
                    using (var dataStream = dataClient.GetStream())
                    using (var fs = new FileStream(dlg.FileName, FileMode.Create))
                    {
                        lblStatus.Text = "Receiving file…";
                        byte[] buffer = new byte[8192];
                        int bytesRead;
                        while ((bytesRead = dataStream.Read(buffer, 0, buffer.Length)) > 0)
                            fs.Write(buffer, 0, bytesRead);
                    }

                    lblStatus.Text = $"Download complete: {dlg.FileName}";
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Error receiving file: {ex.Message}";
            }
        }

        private void SendFile(string serverIp, string filename)
        {
            try
            {
                using (var dataClient = new TcpClient())
                {
                    dataClient.SendTimeout = 10000;
                    dataClient.ReceiveTimeout = 10000;
                    dataClient.Connect(serverIp, 20);

                    using (var dataStream = dataClient.GetStream())
                    using (var fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
                    {
                        lblStatus.Text = "Uploading file…";
                        byte[] buffer = new byte[8192];
                        int bytesRead;
                        while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0)
                            dataStream.Write(buffer, 0, bytesRead);
                        dataStream.Flush();
                    }

                    lblStatus.Text = $"Upload complete: {filename}";
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Error sending file: {ex.Message}";
            }
        }

        private void LbFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblStatus.Text = $"Selected file: {SelectedItem(lbFiles)}";
        }
    }
}
