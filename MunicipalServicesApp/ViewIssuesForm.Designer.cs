namespace MunicipalServicesApp
{
    partial class ViewIssuesForm
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
            lblReportedIssue = new Label();
            lstIssues = new ListBox();
            picLocation = new PictureBox();
            lblTitleLocation = new Label();
            lblDetailLocation = new Label();
            picCategory = new PictureBox();
            lblTitleCategory = new Label();
            lblDetailCategory = new Label();
            picDescription = new PictureBox();
            lblTitleDescription = new Label();
            lblDetailDescription = new Label();
            lblTitleFile = new Label();
            lblDetailFileName = new Label();
            picDetailImage = new PictureBox();
            lblNoFileDetail = new Label();
            btnBackFromView = new Button();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picHeaderLogo).BeginInit();
            pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLocation).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picCategory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picDescription).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picDetailImage).BeginInit();
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
            pnlHeader.Size = new Size(920, 92);
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
            lblHeaderTitle.Size = new Size(296, 40);
            lblHeaderTitle.TabIndex = 1;
            lblHeaderTitle.Text = "View Reported Issues";
            // 
            // lblHeaderSubtitle
            // 
            lblHeaderSubtitle.AutoSize = true;
            lblHeaderSubtitle.Font = new Font("Segoe UI", 9.75F);
            lblHeaderSubtitle.ForeColor = Color.FromArgb(186, 210, 235);
            lblHeaderSubtitle.Location = new Point(102, 56);
            lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            lblHeaderSubtitle.Size = new Size(274, 23);
            lblHeaderSubtitle.TabIndex = 2;
            lblHeaderSubtitle.Text = "See all issues submitted by citizens";
            // 
            // pnlContent
            // 
            pnlContent.Anchor = AnchorStyles.None;
            pnlContent.BackColor = Color.White;
            pnlContent.Controls.Add(lblReportedIssue);
            pnlContent.Controls.Add(lstIssues);
            pnlContent.Controls.Add(picLocation);
            pnlContent.Controls.Add(lblTitleLocation);
            pnlContent.Controls.Add(lblDetailLocation);
            pnlContent.Controls.Add(picCategory);
            pnlContent.Controls.Add(lblTitleCategory);
            pnlContent.Controls.Add(lblDetailCategory);
            pnlContent.Controls.Add(picDescription);
            pnlContent.Controls.Add(lblTitleDescription);
            pnlContent.Controls.Add(lblDetailDescription);
            pnlContent.Controls.Add(lblTitleFile);
            pnlContent.Controls.Add(lblDetailFileName);
            pnlContent.Controls.Add(picDetailImage);
            pnlContent.Controls.Add(lblNoFileDetail);
            pnlContent.Controls.Add(btnBackFromView);
            pnlContent.Location = new Point(40, 118);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(840, 540);
            pnlContent.TabIndex = 0;
            // 
            // lblReportedIssue
            // 
            lblReportedIssue.AutoSize = true;
            lblReportedIssue.Font = new Font("Segoe UI Semibold", 12F);
            lblReportedIssue.ForeColor = Color.FromArgb(30, 41, 59);
            lblReportedIssue.Location = new Point(28, 24);
            lblReportedIssue.Name = "lblReportedIssue";
            lblReportedIssue.Size = new Size(158, 28);
            lblReportedIssue.TabIndex = 0;
            lblReportedIssue.Text = "Reported Issues";
            // 
            // lstIssues
            // 
            lstIssues.Font = new Font("Segoe UI", 10.5F);
            lstIssues.FormattingEnabled = true;
            lstIssues.Location = new Point(28, 58);
            lstIssues.Name = "lstIssues";
            lstIssues.Size = new Size(320, 395);
            lstIssues.TabIndex = 1;
            lstIssues.SelectedIndexChanged += lstIssues_SelectedIndexChanged;
            // 
            // picLocation
            // 
            picLocation.Location = new Point(380, 60);
            picLocation.Name = "picLocation";
            picLocation.Size = new Size(20, 20);
            picLocation.SizeMode = PictureBoxSizeMode.Zoom;
            picLocation.TabIndex = 2;
            picLocation.TabStop = false;
            // 
            // lblTitleLocation
            // 
            lblTitleLocation.AutoSize = true;
            lblTitleLocation.Font = new Font("Segoe UI Semibold", 10.5F);
            lblTitleLocation.ForeColor = Color.FromArgb(100, 116, 139);
            lblTitleLocation.Location = new Point(408, 60);
            lblTitleLocation.Name = "lblTitleLocation";
            lblTitleLocation.Size = new Size(87, 25);
            lblTitleLocation.TabIndex = 3;
            lblTitleLocation.Text = "Location:";
            // 
            // lblDetailLocation
            // 
            lblDetailLocation.AutoSize = true;
            lblDetailLocation.Font = new Font("Segoe UI", 11F);
            lblDetailLocation.ForeColor = Color.FromArgb(30, 41, 59);
            lblDetailLocation.Location = new Point(500, 58);
            lblDetailLocation.Name = "lblDetailLocation";
            lblDetailLocation.Size = new Size(20, 25);
            lblDetailLocation.TabIndex = 4;
            lblDetailLocation.Text = "-";
            // 
            // picCategory
            // 
            picCategory.Location = new Point(380, 105);
            picCategory.Name = "picCategory";
            picCategory.Size = new Size(20, 20);
            picCategory.SizeMode = PictureBoxSizeMode.Zoom;
            picCategory.TabIndex = 5;
            picCategory.TabStop = false;
            // 
            // lblTitleCategory
            // 
            lblTitleCategory.AutoSize = true;
            lblTitleCategory.Font = new Font("Segoe UI Semibold", 10.5F);
            lblTitleCategory.ForeColor = Color.FromArgb(100, 116, 139);
            lblTitleCategory.Location = new Point(408, 105);
            lblTitleCategory.Name = "lblTitleCategory";
            lblTitleCategory.Size = new Size(92, 25);
            lblTitleCategory.TabIndex = 6;
            lblTitleCategory.Text = "Category:";
            // 
            // lblDetailCategory
            // 
            lblDetailCategory.AutoSize = true;
            lblDetailCategory.Font = new Font("Segoe UI", 11F);
            lblDetailCategory.ForeColor = Color.FromArgb(30, 41, 59);
            lblDetailCategory.Location = new Point(500, 103);
            lblDetailCategory.Name = "lblDetailCategory";
            lblDetailCategory.Size = new Size(20, 25);
            lblDetailCategory.TabIndex = 7;
            lblDetailCategory.Text = "-";
            // 
            // picDescription
            // 
            picDescription.Location = new Point(380, 150);
            picDescription.Name = "picDescription";
            picDescription.Size = new Size(20, 20);
            picDescription.SizeMode = PictureBoxSizeMode.Zoom;
            picDescription.TabIndex = 8;
            picDescription.TabStop = false;
            // 
            // lblTitleDescription
            // 
            lblTitleDescription.AutoSize = true;
            lblTitleDescription.Font = new Font("Segoe UI Semibold", 10.5F);
            lblTitleDescription.ForeColor = Color.FromArgb(100, 116, 139);
            lblTitleDescription.Location = new Point(408, 150);
            lblTitleDescription.Name = "lblTitleDescription";
            lblTitleDescription.Size = new Size(112, 25);
            lblTitleDescription.TabIndex = 9;
            lblTitleDescription.Text = "Description:";
            // 
            // lblDetailDescription
            // 
            lblDetailDescription.Font = new Font("Segoe UI", 11F);
            lblDetailDescription.ForeColor = Color.FromArgb(30, 41, 59);
            lblDetailDescription.Location = new Point(380, 180);
            lblDetailDescription.Name = "lblDetailDescription";
            lblDetailDescription.Size = new Size(420, 100);
            lblDetailDescription.TabIndex = 10;
            lblDetailDescription.Text = "-";
            // 
            // lblTitleFile
            // 
            lblTitleFile.AutoSize = true;
            lblTitleFile.Font = new Font("Segoe UI Semibold", 10.5F);
            lblTitleFile.ForeColor = Color.FromArgb(100, 116, 139);
            lblTitleFile.Location = new Point(380, 300);
            lblTitleFile.Name = "lblTitleFile";
            lblTitleFile.Size = new Size(124, 25);
            lblTitleFile.TabIndex = 11;
            lblTitleFile.Text = "Attached File:";
            // 
            // lblDetailFileName
            // 
            lblDetailFileName.AutoSize = true;
            lblDetailFileName.Font = new Font("Segoe UI", 10.5F);
            lblDetailFileName.ForeColor = Color.FromArgb(30, 41, 59);
            lblDetailFileName.Location = new Point(500, 298);
            lblDetailFileName.Name = "lblDetailFileName";
            lblDetailFileName.Size = new Size(180, 25);
            lblDetailFileName.TabIndex = 12;
            lblDetailFileName.Text = "No file was uploaded";
            // 
            // picDetailImage
            // 
            picDetailImage.BorderStyle = BorderStyle.FixedSingle;
            picDetailImage.Location = new Point(380, 335);
            picDetailImage.Name = "picDetailImage";
            picDetailImage.Size = new Size(160, 100);
            picDetailImage.SizeMode = PictureBoxSizeMode.Zoom;
            picDetailImage.TabIndex = 13;
            picDetailImage.TabStop = false;
            picDetailImage.Visible = false;
            // 
            // lblNoFileDetail
            // 
            lblNoFileDetail.AutoSize = true;
            lblNoFileDetail.Font = new Font("Segoe UI", 9.5F);
            lblNoFileDetail.ForeColor = Color.FromArgb(148, 163, 184);
            lblNoFileDetail.Location = new Point(560, 375);
            lblNoFileDetail.Name = "lblNoFileDetail";
            lblNoFileDetail.Size = new Size(146, 21);
            lblNoFileDetail.TabIndex = 14;
            lblNoFileDetail.Text = "No picture attached";
            // 
            // btnBackFromView
            // 
            btnBackFromView.Cursor = Cursors.Hand;
            btnBackFromView.FlatAppearance.BorderSize = 0;
            btnBackFromView.FlatStyle = FlatStyle.Flat;
            btnBackFromView.Font = new Font("Segoe UI Semibold", 11F);
            btnBackFromView.ImageAlign = ContentAlignment.MiddleLeft;
            btnBackFromView.Location = new Point(600, 470);
            btnBackFromView.Name = "btnBackFromView";
            btnBackFromView.Padding = new Padding(14, 0, 8, 0);
            btnBackFromView.Size = new Size(200, 48);
            btnBackFromView.TabIndex = 15;
            btnBackFromView.Text = "   Back to Menu";
            btnBackFromView.TextAlign = ContentAlignment.MiddleLeft;
            btnBackFromView.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBackFromView.Click += btnBackFromView_Click;
            // 
            // ViewIssuesForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            ClientSize = new Size(920, 700);
            Controls.Add(pnlContent);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 9.5F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "ViewIssuesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "View Reported Issues • Municipal Services Portal";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picHeaderLogo).EndInit();
            pnlContent.ResumeLayout(false);
            pnlContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLocation).EndInit();
            ((System.ComponentModel.ISupportInitialize)picCategory).EndInit();
            ((System.ComponentModel.ISupportInitialize)picDescription).EndInit();
            ((System.ComponentModel.ISupportInitialize)picDetailImage).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private PictureBox picHeaderLogo;
        private Label lblHeaderTitle;
        private Label lblHeaderSubtitle;
        private Panel pnlContent;
        private Label lblReportedIssue;
        private ListBox lstIssues;

        private PictureBox picLocation;
        private Label lblTitleLocation;
        private Label lblDetailLocation;

        private PictureBox picCategory;
        private Label lblTitleCategory;
        private Label lblDetailCategory;

        private PictureBox picDescription;
        private Label lblTitleDescription;
        private Label lblDetailDescription;

        private Label lblTitleFile;
        private Label lblDetailFileName;
        private PictureBox picDetailImage;
        private Label lblNoFileDetail;

        private Button btnBackFromView;
    }
}