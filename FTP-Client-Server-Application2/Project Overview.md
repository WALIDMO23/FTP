# FTP Server and Client Application 🌐💻

## Table of Contents
1. [Overview](#overview)
2. [Features](#features)
3. [Project Structure](#project-structure)
4. [How It Works](#how-it-works)
   - [Server](#server)
   - [Client](#client)
5. [Installation and Setup](#installation-and-setup)
6. [Usage](#usage)
7. [Contributing](#contributing)
---

## Overview 📝

This project is a simple implementation of an **FTP (File Transfer Protocol)** server and client application in C#. The server manages client connections, authenticates users 🔑, and handles file uploads 📤, downloads 📥, directory navigation 📂, and listings. The client provides a graphical user interface (GUI) for interacting with the server.

The system uses TCP sockets 🌐 for communication between the server and client, following a basic FTP-like protocol.

---

## Features ✨

### Server Features 🖥️
- **Authentication** 🔐: Supports username (`std`) and password (`123`) authentication.
- **Directory Navigation** 📂: Allows clients to change directories (`CWD`) and navigate back (`CWD ..`).
- **File Operations**:
  - List files and directories (`LIST`) 📋.
  - Upload files to the server (`STOR`) 📤.
  - Download files from the server (`RETR`) 📥.
- **Multi-threading** 🧵: Handles multiple clients concurrently using `ThreadPool`.
- **Error Handling** ⚠️: Provides meaningful error messages for invalid commands or unexpected issues.

### Client Features 🖥️🖱️
- **GUI-Based Interface** 🎨: User-friendly interface built using Windows Forms.
- **File Management**:
  - Browse server directories 📂.
  - Download files from the server 📥.
  - Upload files to the server 📤.
- **Status Updates** 🔄: Displays real-time status updates for all operations.
- **Navigation** 🗺️: Navigate through directories and move back to parent directories.

---

## Project Structure 🏗️

The project consists of two main components:

1. **FTPServer** 🖥️:
   - Implemented in `Server App.txt`.
   - A console application that listens for incoming client connections on port `21` (control port) and `20` (data port).

2. **FTPClient** 🖥️🖱️:
   - Implemented in `Form1.txt` (logic) and `Form1 Designer.txt` (GUI design).
   - A Windows Forms application that provides a GUI for interacting with the FTP server.

---

## How It Works ⚙️

### Server 🖥️

#### Key Components 🔑
- **Control Port (Port 21)** 🛡️: Handles client commands like authentication, directory listing, and navigation.
- **Data Port (Port 20)** 📤📥: Handles file transfers (uploads and downloads).
- **Concurrent Clients** 🧵👥: Uses `ConcurrentDictionary` to manage active clients and their current directories.

#### Workflow 🔄
1. **Startup** 🚀:
   - The server starts listening on port `21` for incoming connections.
   - Each client connection is handled in a separate thread using `ThreadPool`.

2. **Authentication** 🔐:
   - Clients must provide a valid username (`std`) and password (`123`) to access the server.

3. **Commands** 📝:
   - **LIST**: Lists files and directories in the current directory 📋.
   - **CWD**: Changes the current working directory 📂.
   - **RETR**: Sends a file to the client 📥.
   - **STOR**: Receives a file from the client 📤.
   - **EXIT**: Disconnects the client 👋.

4. **File Transfers** 📤📥:
   - File transfers occur over port `20` using a separate `TcpListener` for each transfer.

---

### Client 🖥️🖱️

#### Key Components 🎛️
- **GUI** 🖼️: Built using Windows Forms with controls for connecting to the server, listing files, uploading/downloading files, and navigating directories.
- **Communication** 🌐: Communicates with the server using `TcpClient` over port `21` (control) and port `20` (data).

#### Workflow 🔄
1. **Connection** 🌐:
   - The user enters the server IP address, username, and password 🔑.
   - The client connects to the server and authenticates the user.

2. **Directory Listing** 📋:
   - The `LIST` command retrieves files and directories from the server.
   - Files and directories are displayed in separate list boxes.

3. **File Operations** 📤📥:
   - **Download**: Select a file from the list and download it to the local machine 📥.
   - **Upload**: Select a file from the local machine and upload it to the server 📤.

4. **Navigation** 🗺️:
   - Open folders by selecting them from the folder list 📂.
   - Move back to the parent directory using the "Back" button ⬅️.

---

## Installation and Setup 🛠️

### Prerequisites 📋
- **.NET Framework** 🟩: Ensure you have .NET Framework installed on your system.

### Steps 🚀
1. Clone the repository:
   ```bash
   git clone https://github.com/your-repo/ftp-server-client.git
   cd ftp-server-client
   ```

2. Build the Projects 🏗️:
   - Open the solution in Visual Studio.
   - Build both the server and client projects.

3. Configure Root Directory 📂:
   - Update the `RootDirectory` variable in `Server App.txt` to point to your desired root directory:
     ```csharp
     private static string RootDirectory = @"C:\Your\Root\Directory";
     ```

4. Run the Server 🖥️:
   - Execute the server application to start listening for connections.

5. Run the Client 🖥️🖱️:
   - Launch the client application and connect to the server using the appropriate IP address.

---

## Usage 🖱️

### Server 🖥️
1. Start the server application 🚀.
2. The server will display logs for client connections, disconnections, and operations 📝.

### Client 🖥️🖱️
1. Enter the server IP address (default: `127.0.0.1`), username (`std`), and password (`123`) 🔑.
2. Click "Connect" to establish a connection 🌐.
3. Use the buttons to:
   - **List**: View files and directories 📋.
   - **Download**: Save a file from the server to your local machine 📥.
   - **Upload**: Send a file from your local machine to the server 📤.
   - **Open Folder**: Navigate into a directory 📂.
   - **Back**: Move to the parent directory ⬅️.

---

## Contributing 🤝

Contributions are welcome! To contribute:
1. Fork the repository.
2. Create a new branch for your feature or bug fix.
3. Submit a pull request with a detailed description of your changes.

---

Feel free to reach out if you have any questions or need further assistance! 🙌📧
