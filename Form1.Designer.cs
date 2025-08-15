namespace SimpleIPScan
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
            maskedEndIP = new MaskedTextBox();
            lvIPAddresses = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            btnScan = new Button();
            maskedStartIP = new MaskedTextBox();
            _backgroundWorker = new System.ComponentModel.BackgroundWorker();
            label1 = new Label();
            label2 = new Label();
            chkPingBackup = new CheckBox();
            progressBar1 = new ProgressBar();
            lblStatus = new Label();
            SuspendLayout();
            // 
            // maskedEndIP
            // 
            maskedEndIP.Location = new Point(210, 24);
            maskedEndIP.Name = "maskedEndIP";
            maskedEndIP.Size = new Size(113, 23);
            maskedEndIP.TabIndex = 1;
            // 
            // lvIPAddresses
            // 
            lvIPAddresses.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lvIPAddresses.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader4 });
            lvIPAddresses.FullRowSelect = true;
            lvIPAddresses.GridLines = true;
            lvIPAddresses.Location = new Point(12, 63);
            lvIPAddresses.Name = "lvIPAddresses";
            lvIPAddresses.Size = new Size(574, 600);
            lvIPAddresses.TabIndex = 3;
            lvIPAddresses.UseCompatibleStateImageBehavior = false;
            lvIPAddresses.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "IP Address";
            columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Host Name";
            columnHeader2.Width = 350;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Ping";
            // 
            // btnScan
            // 
            btnScan.Location = new Point(329, 24);
            btnScan.Name = "btnScan";
            btnScan.Size = new Size(71, 23);
            btnScan.TabIndex = 2;
            btnScan.Text = "Scan";
            btnScan.UseVisualStyleBackColor = true;
            btnScan.Click += btnScan_Click;
            // 
            // maskedStartIP
            // 
            maskedStartIP.Location = new Point(72, 24);
            maskedStartIP.Name = "maskedStartIP";
            maskedStartIP.Size = new Size(113, 23);
            maskedStartIP.TabIndex = 0;
            // 
            // label1
            // 
            label1.Location = new Point(12, 23);
            label1.Name = "label1";
            label1.Size = new Size(58, 23);
            label1.TabIndex = 4;
            label1.Text = "IP Range";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(188, 28);
            label2.Name = "label2";
            label2.Size = new Size(20, 15);
            label2.TabIndex = 5;
            label2.Text = "To";
            // 
            // chkPingBackup
            // 
            chkPingBackup.AutoSize = true;
            chkPingBackup.Location = new Point(404, 27);
            chkPingBackup.Name = "chkPingBackup";
            chkPingBackup.Size = new Size(152, 19);
            chkPingBackup.TabIndex = 6;
            chkPingBackup.Text = "Perform Ping as Backup";
            chkPingBackup.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 716);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(574, 23);
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.TabIndex = 7;
            // 
            // lblStatus
            // 
            lblStatus.Location = new Point(12, 675);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(574, 23);
            lblStatus.TabIndex = 8;
            lblStatus.Text = "Let's Start A Scan Of IP Addresses";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(598, 751);
            Controls.Add(lblStatus);
            Controls.Add(progressBar1);
            Controls.Add(chkPingBackup);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(maskedStartIP);
            Controls.Add(btnScan);
            Controls.Add(lvIPAddresses);
            Controls.Add(maskedEndIP);
            Name = "Form1";
            Text = "Simple IP Scan";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaskedTextBox maskedEndIP;
        private ListView lvIPAddresses;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private Button btnScan;
        private MaskedTextBox maskedStartIP;
        private System.ComponentModel.BackgroundWorker _backgroundWorker;
        private Label label1;
        private Label label2;
        private ColumnHeader columnHeader4;
        private CheckBox chkPingBackup;
        private ProgressBar progressBar1;
        private Label lblStatus;
    }
}