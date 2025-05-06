namespace FTP_Client_Application
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        // Designer controls
        private System.Windows.Forms.TextBox txtServerIP;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnList;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnExit;

        private System.Windows.Forms.Label lblStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            txtServerIP = new TextBox();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            btnConnect = new Button();
            btnList = new Button();
            btnDownload = new Button();
            btnUpload = new Button();
            btnExit = new Button();
            lblStatus = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            lbFiles = new ListBox();
            lbFolders = new ListBox();
            btnCWD = new Button();
            btnBack = new Button();
            SuspendLayout();
            // 
            // txtServerIP
            // 
            txtServerIP.Location = new Point(15, 35);
            txtServerIP.Margin = new Padding(3, 4, 3, 4);
            txtServerIP.Name = "txtServerIP";
            txtServerIP.Size = new Size(150, 27);
            txtServerIP.TabIndex = 0;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(186, 35);
            txtUsername.Margin = new Padding(3, 4, 3, 4);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(120, 27);
            txtUsername.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(322, 35);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(120, 27);
            txtPassword.TabIndex = 2;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(463, 31);
            btnConnect.Margin = new Padding(3, 4, 3, 4);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(80, 34);
            btnConnect.TabIndex = 3;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += BtnConnect_Click;
            // 
            // btnList
            // 
            btnList.Location = new Point(193, 394);
            btnList.Margin = new Padding(3, 4, 3, 4);
            btnList.Name = "btnList";
            btnList.Size = new Size(68, 38);
            btnList.TabIndex = 4;
            btnList.Text = "List";
            btnList.UseVisualStyleBackColor = true;
            btnList.Click += BtnList_Click;
            // 
            // btnDownload
            // 
            btnDownload.Location = new Point(15, 394);
            btnDownload.Margin = new Padding(3, 4, 3, 4);
            btnDownload.Name = "btnDownload";
            btnDownload.Size = new Size(90, 38);
            btnDownload.TabIndex = 5;
            btnDownload.Text = "Download";
            btnDownload.UseVisualStyleBackColor = true;
            btnDownload.Click += BtnDownload_Click;
            // 
            // btnUpload
            // 
            btnUpload.Location = new Point(111, 394);
            btnUpload.Margin = new Padding(3, 4, 3, 4);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(76, 38);
            btnUpload.TabIndex = 6;
            btnUpload.Text = "Upload";
            btnUpload.UseVisualStyleBackColor = true;
            btnUpload.Click += BtnUpload_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(580, 394);
            btnExit.Margin = new Padding(3, 4, 3, 4);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(100, 38);
            btnExit.TabIndex = 7;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            // 
            // lblStatus
            // 
            lblStatus.BorderStyle = BorderStyle.Fixed3D;
            lblStatus.Location = new Point(15, 77);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(665, 35);
            lblStatus.TabIndex = 8;
            lblStatus.Text = "Connection Status";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(322, 9);
            label1.Name = "label1";
            label1.Size = new Size(70, 20);
            label1.TabIndex = 11;
            label1.Text = "Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(186, 9);
            label2.Name = "label2";
            label2.Size = new Size(75, 20);
            label2.TabIndex = 12;
            label2.Text = "Username";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 9);
            label3.Name = "label3";
            label3.Size = new Size(123, 20);
            label3.TabIndex = 13;
            label3.Text = "Server IP Address";
            // 
            // lbFiles
            // 
            lbFiles.FormattingEnabled = true;
            lbFiles.Location = new Point(15, 131);
            lbFiles.Name = "lbFiles";
            lbFiles.Size = new Size(246, 244);
            lbFiles.TabIndex = 14;
            lbFiles.SelectedIndexChanged += LbFiles_SelectedIndexChanged;
            // 
            // lbFolders
            // 
            lbFolders.FormattingEnabled = true;
            lbFolders.Location = new Point(334, 131);
            lbFolders.Name = "lbFolders";
            lbFolders.Size = new Size(346, 244);
            lbFolders.TabIndex = 15;
            // 
            // btnCWD
            // 
            btnCWD.Location = new Point(334, 394);
            btnCWD.Name = "btnCWD";
            btnCWD.Size = new Size(108, 38);
            btnCWD.TabIndex = 16;
            btnCWD.Text = "Open Folder";
            btnCWD.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(448, 394);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(126, 38);
            btnBack.TabIndex = 17;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(695, 450);
            Controls.Add(btnBack);
            Controls.Add(btnCWD);
            Controls.Add(lbFolders);
            Controls.Add(lbFiles);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtServerIP);
            Controls.Add(txtUsername);
            Controls.Add(txtPassword);
            Controls.Add(btnConnect);
            Controls.Add(btnList);
            Controls.Add(btnDownload);
            Controls.Add(btnUpload);
            Controls.Add(btnExit);
            Controls.Add(lblStatus);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "Form1";
            Text = "FTP Client";
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private ListBox lbFiles;
        private ListBox lbFolders;
        private Button btnCWD;
        private Button btnBack;
    }
}
