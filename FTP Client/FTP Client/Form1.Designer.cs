namespace FTP_Client
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Connectbtn = new Button();
            Downloadbtn = new Button();
            Uploadbtn = new Button();
            Savebtn = new Button();
            Backbtn = new Button();
            Exitbtn = new Button();
            Listbtn = new Button();
            txtServerIP = new TextBox();
            txtUserName = new TextBox();
            txtPassword = new TextBox();
            ShowBox = new ListBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            OpenFolderbtn = new Button();
            SuspendLayout();
            // 
            // Connectbtn
            // 
            Connectbtn.Location = new Point(261, 68);
            Connectbtn.Name = "Connectbtn";
            Connectbtn.Size = new Size(94, 29);
            Connectbtn.TabIndex = 0;
            Connectbtn.Text = "Connect";
            Connectbtn.UseVisualStyleBackColor = true;
            // 
            // Downloadbtn
            // 
            Downloadbtn.Location = new Point(583, 28);
            Downloadbtn.Name = "Downloadbtn";
            Downloadbtn.Size = new Size(94, 29);
            Downloadbtn.TabIndex = 1;
            Downloadbtn.Text = "Download";
            Downloadbtn.UseVisualStyleBackColor = true;
            // 
            // Uploadbtn
            // 
            Uploadbtn.Location = new Point(724, 28);
            Uploadbtn.Name = "Uploadbtn";
            Uploadbtn.Size = new Size(94, 29);
            Uploadbtn.TabIndex = 2;
            Uploadbtn.Text = "Upload";
            Uploadbtn.UseVisualStyleBackColor = true;
            // 
            // Savebtn
            // 
            Savebtn.Location = new Point(814, 95);
            Savebtn.Name = "Savebtn";
            Savebtn.Size = new Size(94, 29);
            Savebtn.TabIndex = 3;
            Savebtn.Text = "Save ";
            Savebtn.UseVisualStyleBackColor = true;
            // 
            // Backbtn
            // 
            Backbtn.Location = new Point(855, 240);
            Backbtn.Name = "Backbtn";
            Backbtn.Size = new Size(94, 54);
            Backbtn.TabIndex = 4;
            Backbtn.Text = "Back";
            Backbtn.UseVisualStyleBackColor = true;
            // 
            // Exitbtn
            // 
            Exitbtn.Location = new Point(855, 321);
            Exitbtn.Name = "Exitbtn";
            Exitbtn.Size = new Size(94, 63);
            Exitbtn.TabIndex = 5;
            Exitbtn.Text = "Exit";
            Exitbtn.UseVisualStyleBackColor = true;
            // 
            // Listbtn
            // 
            Listbtn.Location = new Point(868, 28);
            Listbtn.Name = "Listbtn";
            Listbtn.Size = new Size(94, 29);
            Listbtn.TabIndex = 6;
            Listbtn.Text = "List";
            Listbtn.UseVisualStyleBackColor = true;
            // 
            // txtServerIP
            // 
            txtServerIP.Location = new Point(85, 12);
            txtServerIP.Name = "txtServerIP";
            txtServerIP.Size = new Size(125, 27);
            txtServerIP.TabIndex = 7;
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(85, 69);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(125, 27);
            txtUserName.TabIndex = 8;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(85, 136);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(125, 27);
            txtPassword.TabIndex = 9;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // ShowBox
            // 
            ShowBox.FormattingEnabled = true;
            ShowBox.Location = new Point(12, 217);
            ShowBox.Name = "ShowBox";
            ShowBox.Size = new Size(778, 204);
            ShowBox.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1, 15);
            label1.Name = "label1";
            label1.Size = new Size(62, 20);
            label1.TabIndex = 12;
            label1.Text = "ServerIP";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1, 72);
            label2.Name = "label2";
            label2.Size = new Size(78, 20);
            label2.TabIndex = 13;
            label2.Text = "UserName";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1, 136);
            label3.Name = "label3";
            label3.Size = new Size(64, 20);
            label3.TabIndex = 14;
            label3.Text = "Pasword";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1, 184);
            label4.Name = "label4";
            label4.Size = new Size(70, 20);
            label4.TabIndex = 15;
            label4.Text = "View Box";
            // 
            // OpenFolderbtn
            // 
            OpenFolderbtn.Location = new Point(658, 95);
            OpenFolderbtn.Name = "OpenFolderbtn";
            OpenFolderbtn.Size = new Size(108, 29);
            OpenFolderbtn.TabIndex = 16;
            OpenFolderbtn.Text = "Open Folder ";
            OpenFolderbtn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkGoldenrod;
            ClientSize = new Size(1047, 450);
            Controls.Add(OpenFolderbtn);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ShowBox);
            Controls.Add(txtPassword);
            Controls.Add(txtUserName);
            Controls.Add(txtServerIP);
            Controls.Add(Listbtn);
            Controls.Add(Exitbtn);
            Controls.Add(Backbtn);
            Controls.Add(Savebtn);
            Controls.Add(Uploadbtn);
            Controls.Add(Downloadbtn);
            Controls.Add(Connectbtn);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Connectbtn;
        private Button Downloadbtn;
        private Button Uploadbtn;
        private Button Savebtn;
        private Button Backbtn;
        private Button Exitbtn;
        private Button Listbtn;
        private TextBox txtServerIP;
        private TextBox txtUserName;
        private TextBox txtPassword;
        private ListBox ShowBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button OpenFolderbtn;
    }
}
