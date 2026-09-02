namespace MunicipalServicesApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            btnReportIssues = new Button();
            btnLocalEvents = new Button();
            btnServiceStatus = new Button();
            btnViewIssues = new Button();
            pnlHeader = new Panel();
            picHeaderLogo = new PictureBox();
            label2 = new Label();
            label1 = new Label();
            pnlContent = new Panel();
            lblSection = new Label();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picHeaderLogo).BeginInit();
            pnlContent.SuspendLayout();
            SuspendLayout();
            // 
            // btnReportIssues
            // 
            btnReportIssues.Cursor = Cursors.Hand;
            btnReportIssues.FlatAppearance.BorderSize = 0;
            btnReportIssues.FlatStyle = FlatStyle.Flat;
            btnReportIssues.Font = new Font("Segoe UI Semibold", 11.5F);
            btnReportIssues.Location = new Point(36, 72);
            btnReportIssues.Name = "btnReportIssues";
            btnReportIssues.Size = new Size(748, 64);
            btnReportIssues.TabIndex = 1;
            btnReportIssues.Text = "  Report an Issue";
            btnReportIssues.TextAlign = ContentAlignment.MiddleLeft;
            btnReportIssues.UseVisualStyleBackColor = false;
            btnReportIssues.Click += btnReportIssues_Click;
            // 
            // btnLocalEvents
            // 
            btnLocalEvents.Enabled = false;
            btnLocalEvents.FlatAppearance.BorderSize = 0;
            btnLocalEvents.FlatStyle = FlatStyle.Flat;
            btnLocalEvents.Font = new Font("Segoe UI", 11F);
            btnLocalEvents.Location = new Point(36, 232);
            btnLocalEvents.Name = "btnLocalEvents";
            btnLocalEvents.Size = new Size(748, 64);
            btnLocalEvents.TabIndex = 3;
            btnLocalEvents.Text = "  Local Events & Announcements   (Coming soon)";
            btnLocalEvents.TextAlign = ContentAlignment.MiddleLeft;
            btnLocalEvents.UseVisualStyleBackColor = false;
            // 
            // btnServiceStatus
            // 
            btnServiceStatus.Enabled = false;
            btnServiceStatus.FlatAppearance.BorderSize = 0;
            btnServiceStatus.FlatStyle = FlatStyle.Flat;
            btnServiceStatus.Font = new Font("Segoe UI", 11F);
            btnServiceStatus.Location = new Point(36, 312);
            btnServiceStatus.Name = "btnServiceStatus";
            btnServiceStatus.Size = new Size(748, 64);
            btnServiceStatus.TabIndex = 4;
            btnServiceStatus.Text = "  Service Request Status   (Coming soon)";
            btnServiceStatus.TextAlign = ContentAlignment.MiddleLeft;
            btnServiceStatus.UseVisualStyleBackColor = false;
            // 
            // btnViewIssues
            // 
            btnViewIssues.Cursor = Cursors.Hand;
            btnViewIssues.FlatAppearance.BorderSize = 0;
            btnViewIssues.FlatStyle = FlatStyle.Flat;
            btnViewIssues.Font = new Font("Segoe UI Semibold", 11.5F);
            btnViewIssues.Location = new Point(36, 152);
            btnViewIssues.Name = "btnViewIssues";
            btnViewIssues.Size = new Size(748, 64);
            btnViewIssues.TabIndex = 2;
            btnViewIssues.Text = "  View Reported Issues";
            btnViewIssues.TextAlign = ContentAlignment.MiddleLeft;
            btnViewIssues.UseVisualStyleBackColor = false;
            btnViewIssues.Click += btnViewIssues_Click;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(15, 76, 129);
            pnlHeader.Controls.Add(picHeaderLogo);
            pnlHeader.Controls.Add(label2);
            pnlHeader.Controls.Add(label1);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(32, 0, 32, 0);
            pnlHeader.Size = new Size(920, 92);
            pnlHeader.TabIndex = 0;
            // 
            // picHeaderLogo
            // 
            picHeaderLogo.BackColor = Color.Transparent;
            picHeaderLogo.Location = new Point(32, 20);
            picHeaderLogo.Name = "picHeaderLogo";
            picHeaderLogo.Size = new Size(52, 52);
            picHeaderLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picHeaderLogo.TabIndex = 2;
            picHeaderLogo.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F);
            label2.ForeColor = Color.FromArgb(186, 210, 235);
            label2.Location = new Point(102, 56);
            label2.Name = "label2";
            label2.Size = new Size(392, 23);
            label2.TabIndex = 1;
            label2.Text = "Report issues  •  Stay informed  •  Get things done";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 17F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(98, 18);
            label1.Name = "label1";
            label1.Size = new Size(350, 40);
            label1.TabIndex = 0;
            label1.Text = "Municipal Services Portal";
            // 
            // pnlContent
            // 
            pnlContent.Anchor = AnchorStyles.None;
            pnlContent.BackColor = Color.White;
            pnlContent.Controls.Add(lblSection);
            pnlContent.Controls.Add(btnReportIssues);
            pnlContent.Controls.Add(btnViewIssues);
            pnlContent.Controls.Add(btnLocalEvents);
            pnlContent.Controls.Add(btnServiceStatus);
            pnlContent.Location = new Point(48, 128);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(824, 412);
            pnlContent.TabIndex = 1;
            // 
            // lblSection
            // 
            lblSection.AutoSize = true;
            lblSection.Font = new Font("Segoe UI Semibold", 12F);
            lblSection.ForeColor = Color.FromArgb(51, 65, 85);
            lblSection.Location = new Point(36, 28);
            lblSection.Name = "lblSection";
            lblSection.Size = new Size(264, 28);
            lblSection.TabIndex = 5;
            lblSection.Text = "What would you like to do?";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            ClientSize = new Size(920, 580);
            Controls.Add(pnlContent);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 9.5F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Municipal Services Portal";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picHeaderLogo).EndInit();
            pnlContent.ResumeLayout(false);
            pnlContent.PerformLayout();
            ResumeLayout(false);
        }
        #endregion
        private Button btnReportIssues;
        private Button btnLocalEvents;
        private Button btnServiceStatus;
        private Button btnViewIssues;
        private Panel pnlHeader;
        private PictureBox picHeaderLogo;
        private Label label1;
        private Label label2;
        private Panel pnlContent;
        private Label lblSection;
    }
}