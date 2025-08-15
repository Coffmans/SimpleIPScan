namespace SimpleIPScan
{
    partial class ResultsWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTotalTime = new Label();
            lblUnreachable = new Label();
            lblReachable = new Label();
            lblTotalAddresse = new Label();
            label1 = new Label();
            lblIPRange = new Label();
            txtIPRange = new TextBox();
            txtTotalNumber = new TextBox();
            txtTotalReachable = new TextBox();
            txtTotalUnreachable = new TextBox();
            txtTotalTime = new TextBox();
            btnClose = new Button();
            SuspendLayout();
            // 
            // lblTotalTime
            // 
            lblTotalTime.Location = new Point(12, 183);
            lblTotalTime.Name = "lblTotalTime";
            lblTotalTime.Size = new Size(105, 16);
            lblTotalTime.TabIndex = 8;
            lblTotalTime.Text = "Processing Time:";
            lblTotalTime.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblUnreachable
            // 
            lblUnreachable.Location = new Point(12, 145);
            lblUnreachable.Name = "lblUnreachable";
            lblUnreachable.Size = new Size(105, 16);
            lblUnreachable.TabIndex = 6;
            lblUnreachable.Text = "Unresearchable:";
            lblUnreachable.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblReachable
            // 
            lblReachable.Location = new Point(12, 107);
            lblReachable.Name = "lblReachable";
            lblReachable.Size = new Size(105, 16);
            lblReachable.TabIndex = 4;
            lblReachable.Text = "Reachable:";
            lblReachable.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTotalAddresse
            // 
            lblTotalAddresse.Location = new Point(12, 69);
            lblTotalAddresse.Name = "lblTotalAddresse";
            lblTotalAddresse.Size = new Size(105, 16);
            lblTotalAddresse.TabIndex = 2;
            lblTotalAddresse.Text = "# of IP Addresses";
            lblTotalAddresse.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.Location = new Point(12, 31);
            label1.Name = "label1";
            label1.Size = new Size(105, 16);
            label1.TabIndex = 0;
            label1.Text = "IP Range:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblIPRange
            // 
            lblIPRange.AutoSize = true;
            lblIPRange.Location = new Point(197, 38);
            lblIPRange.Name = "lblIPRange";
            lblIPRange.Size = new Size(0, 15);
            lblIPRange.TabIndex = 15;
            // 
            // txtIPRange
            // 
            txtIPRange.BackColor = SystemColors.InactiveBorder;
            txtIPRange.BorderStyle = BorderStyle.None;
            txtIPRange.Enabled = false;
            txtIPRange.Location = new Point(120, 31);
            txtIPRange.Name = "txtIPRange";
            txtIPRange.Size = new Size(234, 16);
            txtIPRange.TabIndex = 1;
            // 
            // txtTotalNumber
            // 
            txtTotalNumber.BackColor = SystemColors.InactiveBorder;
            txtTotalNumber.BorderStyle = BorderStyle.None;
            txtTotalNumber.Enabled = false;
            txtTotalNumber.Location = new Point(120, 69);
            txtTotalNumber.Name = "txtTotalNumber";
            txtTotalNumber.Size = new Size(234, 16);
            txtTotalNumber.TabIndex = 3;
            // 
            // txtTotalReachable
            // 
            txtTotalReachable.BackColor = SystemColors.InactiveBorder;
            txtTotalReachable.BorderStyle = BorderStyle.None;
            txtTotalReachable.Enabled = false;
            txtTotalReachable.Location = new Point(120, 107);
            txtTotalReachable.Name = "txtTotalReachable";
            txtTotalReachable.Size = new Size(234, 16);
            txtTotalReachable.TabIndex = 5;
            // 
            // txtTotalUnreachable
            // 
            txtTotalUnreachable.BackColor = SystemColors.InactiveBorder;
            txtTotalUnreachable.BorderStyle = BorderStyle.None;
            txtTotalUnreachable.Enabled = false;
            txtTotalUnreachable.Location = new Point(120, 145);
            txtTotalUnreachable.Name = "txtTotalUnreachable";
            txtTotalUnreachable.Size = new Size(234, 16);
            txtTotalUnreachable.TabIndex = 7;
            // 
            // txtTotalTime
            // 
            txtTotalTime.BackColor = SystemColors.InactiveBorder;
            txtTotalTime.BorderStyle = BorderStyle.None;
            txtTotalTime.Enabled = false;
            txtTotalTime.Location = new Point(120, 183);
            txtTotalTime.Name = "txtTotalTime";
            txtTotalTime.Size = new Size(234, 16);
            txtTotalTime.TabIndex = 9;
            // 
            // btnClose
            // 
            btnClose.DialogResult = DialogResult.Cancel;
            btnClose.Location = new Point(151, 235);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 10;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // ResultsWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(377, 270);
            Controls.Add(btnClose);
            Controls.Add(txtTotalTime);
            Controls.Add(txtTotalUnreachable);
            Controls.Add(txtTotalReachable);
            Controls.Add(txtTotalNumber);
            Controls.Add(txtIPRange);
            Controls.Add(lblIPRange);
            Controls.Add(label1);
            Controls.Add(lblTotalTime);
            Controls.Add(lblUnreachable);
            Controls.Add(lblReachable);
            Controls.Add(lblTotalAddresse);
            Name = "ResultsWindow";
            Text = "Results of the IP Address Scan";
            Load += ResultsWindow_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTotalTime;
        private Label lblUnreachable;
        private Label lblReachable;
        private Label lblTotalAddresse;
        private Label label1;
        private Label lblIPRange;
        private TextBox txtIPRange;
        private TextBox txtTotalNumber;
        private TextBox txtTotalReachable;
        private TextBox txtTotalUnreachable;
        private TextBox txtTotalTime;
        private Button btnClose;
    }
}