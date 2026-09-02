namespace MunicipalServicesApp
{
    partial class ThankYouForm
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
            pnlHeader = new Panel();
            picHeaderLogo = new PictureBox();
            lblHeaderTitle = new Label();
            lblHeaderSubtitle = new Label();
            pnlContent = new Panel();
            picSuccess = new PictureBox();
            lblThankYouTitle = new Label();
            lblThankYouMessage = new Label();
            lblSummary = new Label();
            btnBackToMenuFromThanks = new Button();
            btnViewFromThanks = new Button();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picHeaderLogo).BeginInit();
            pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picSuccess).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(15, 76, 129);
            pnlHeader.Controls.Add(picHeaderLogo);
            pnlHeader.Controls.Add(lblHeaderTitle);
            pnlHeader.Controls.Add(lblHeaderSubtitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(720, 92);
            pnlHeader.TabIndex = 1;
            // 
            // picHeaderLogo
            // 
            picHeaderLogo.BackColor = Color.Transparent;
            picHeaderLogo.Location = new Point(32, 20);
            picHeaderLogo.Name = "picHeaderLogo";
            picHeaderLogo.Size = new Size(52, 52);
            picHeaderLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picHeaderLogo.TabIndex = 0;
            picHeaderLogo.TabStop = false;
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI Semibold", 17F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.White;
            lblHeaderTitle.Location = new Point(98, 18);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(350, 40);
            lblHeaderTitle.TabIndex = 1;
            lblHeaderTitle.Text = "Municipal Services Portal";
            // 
            // lblHeaderSubtitle
            // 
            lblHeaderSubtitle.AutoSize = true;
            lblHeaderSubtitle.Font = new Font("Segoe UI", 9.75F);
            lblHeaderSubtitle.ForeColor = Color.FromArgb(186, 210, 235);
            lblHeaderSubtitle.Location = new Point(102, 56);
            lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            lblHeaderSubtitle.Size = new Size(206, 23);
            lblHeaderSubtitle.TabIndex = 2;
            lblHeaderSubtitle.Text = "Thank you for your report";
            // 
            // pnlContent
            // 
            pnlContent.Anchor = AnchorStyles.None;
            pnlContent.BackColor = Color.White;
            pnlContent.Controls.Add(picSuccess);
            pnlContent.Controls.Add(lblThankYouTitle);
            pnlContent.Controls.Add(lblThankYouMessage);
            pnlContent.Controls.Add(lblSummary);
            pnlContent.Controls.Add(btnBackToMenuFromThanks);
            pnlContent.Controls.Add(btnViewFromThanks);
            pnlContent.Location = new Point(60, 130);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(600, 410);
            pnlContent.TabIndex = 0;
            // 
            // picSuccess
            // 
            picSuccess.Location = new Point(260, 28);
            picSuccess.Name = "picSuccess";
            picSuccess.Size = new Size(80, 80);
            picSuccess.SizeMode = PictureBoxSizeMode.Zoom;
            picSuccess.TabIndex = 0;
            picSuccess.TabStop = false;
            // 
            // lblThankYouTitle
            // 
            lblThankYouTitle.AutoSize = true;
            lblThankYouTitle.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            lblThankYouTitle.ForeColor = Color.FromArgb(15, 76, 129);
            lblThankYouTitle.Location = new Point(205, 120);
            lblThankYouTitle.Name = "lblThankYouTitle";
            lblThankYouTitle.Size = new Size(191, 46);
            lblThankYouTitle.TabIndex = 1;
            lblThankYouTitle.Text = "Thank You!";
            // 
            // lblThankYouMessage
            // 
            lblThankYouMessage.AutoSize = true;
            lblThankYouMessage.Font = new Font("Segoe UI", 11F);
            lblThankYouMessage.ForeColor = Color.FromArgb(71, 85, 105);
            lblThankYouMessage.Location = new Point(135, 170);
            lblThankYouMessage.Name = "lblThankYouMessage";
            lblThankYouMessage.Size = new Size(364, 25);
            lblThankYouMessage.TabIndex = 2;
            lblThankYouMessage.Text = "Your issue has been reported successfully.";
            // 
            // lblSummary
            // 
            lblSummary.AutoSize = true;
            lblSummary.Font = new Font("Segoe UI", 10.5F);
            lblSummary.ForeColor = Color.FromArgb(51, 65, 85);
            lblSummary.Location = new Point(160, 220);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new Size(105, 50);
            lblSummary.TabIndex = 3;
            lblSummary.Text = "Category: ...\nLocation: ...";
            lblSummary.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnBackToMenuFromThanks
            // 
            btnBackToMenuFromThanks.Cursor = Cursors.Hand;
            btnBackToMenuFromThanks.FlatAppearance.BorderSize = 0;
            btnBackToMenuFromThanks.FlatStyle = FlatStyle.Flat;
            btnBackToMenuFromThanks.Font = new Font("Segoe UI Semibold", 10.5F);
            btnBackToMenuFromThanks.ImageAlign = ContentAlignment.MiddleLeft;
            btnBackToMenuFromThanks.Location = new Point(45, 315);
            btnBackToMenuFromThanks.Name = "btnBackToMenuFromThanks";
            btnBackToMenuFromThanks.Padding = new Padding(12, 0, 8, 0);
            btnBackToMenuFromThanks.Size = new Size(255, 52);
            btnBackToMenuFromThanks.TabIndex = 4;
            btnBackToMenuFromThanks.Text = "    Back to Main Menu";
            btnBackToMenuFromThanks.TextAlign = ContentAlignment.MiddleLeft;
            btnBackToMenuFromThanks.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBackToMenuFromThanks.Click += btnBackToMenuFromThanks_Click;
            // 
            // btnViewFromThanks
            // 
            btnViewFromThanks.Cursor = Cursors.Hand;
            btnViewFromThanks.FlatAppearance.BorderSize = 0;
            btnViewFromThanks.FlatStyle = FlatStyle.Flat;
            btnViewFromThanks.Font = new Font("Segoe UI Semibold", 10.5F);
            btnViewFromThanks.Location = new Point(320, 315);
            btnViewFromThanks.Name = "btnViewFromThanks";
            btnViewFromThanks.Size = new Size(230, 52);
            btnViewFromThanks.TabIndex = 5;
            btnViewFromThanks.Text = "View Reported Issues";
            btnViewFromThanks.Click += btnViewFromThanks_Click;
            // 
            // ThankYouForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            ClientSize = new Size(720, 590);
            Controls.Add(pnlContent);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 9.5F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "ThankYouForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thank You • Municipal Services Portal";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picHeaderLogo).EndInit();
            pnlContent.ResumeLayout(false);
            pnlContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picSuccess).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private PictureBox picHeaderLogo;
        private Label lblHeaderTitle;
        private Label lblHeaderSubtitle;
        private Panel pnlContent;
        private PictureBox picSuccess;
        private Label lblThankYouTitle;
        private Label lblThankYouMessage;
        private Label lblSummary;
        private Button btnBackToMenuFromThanks;
        private Button btnViewFromThanks;
    }
}