namespace MunicipalServicesApp
{
    partial class ReportIssuesForm
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
            lblSection = new Label();
            picLocation = new PictureBox();
            lblLocation = new Label();
            txtLocation = new TextBox();
            lblLocationError = new Label();
            picCategory = new PictureBox();
            lblCategory = new Label();
            cmbCategory = new ComboBox();
            lblCategoryError = new Label();
            picDescription = new PictureBox();
            lblDescription = new Label();
            rtbDescription = new RichTextBox();
            lblDescriptionError = new Label();
            btnAttach = new Button();
            lblAttachment = new Label();
            picAttachment = new PictureBox();
            lblNoPicture = new Label();
            progressEngagement = new ProgressBar();
            lblEngagement = new Label();
            btnSubmit = new Button();
            btnBack = new Button();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picHeaderLogo).BeginInit();
            pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLocation).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picCategory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picDescription).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picAttachment).BeginInit();
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
            lblHeaderTitle.Size = new Size(219, 40);
            lblHeaderTitle.TabIndex = 1;
            lblHeaderTitle.Text = "Report an Issue";
            // 
            // lblHeaderSubtitle
            // 
            lblHeaderSubtitle.AutoSize = true;
            lblHeaderSubtitle.Font = new Font("Segoe UI", 9.75F);
            lblHeaderSubtitle.ForeColor = Color.FromArgb(186, 210, 235);
            lblHeaderSubtitle.Location = new Point(102, 56);
            lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            lblHeaderSubtitle.Size = new Size(276, 23);
            lblHeaderSubtitle.TabIndex = 2;
            lblHeaderSubtitle.Text = "Help us improve municipal services";
            // 
            // pnlContent
            // 
            pnlContent.Anchor = AnchorStyles.None;
            pnlContent.BackColor = Color.White;
            pnlContent.Controls.Add(lblSection);
            pnlContent.Controls.Add(picLocation);
            pnlContent.Controls.Add(lblLocation);
            pnlContent.Controls.Add(txtLocation);
            pnlContent.Controls.Add(lblLocationError);
            pnlContent.Controls.Add(picCategory);
            pnlContent.Controls.Add(lblCategory);
            pnlContent.Controls.Add(cmbCategory);
            pnlContent.Controls.Add(lblCategoryError);
            pnlContent.Controls.Add(picDescription);
            pnlContent.Controls.Add(lblDescription);
            pnlContent.Controls.Add(rtbDescription);
            pnlContent.Controls.Add(lblDescriptionError);
            pnlContent.Controls.Add(btnAttach);
            pnlContent.Controls.Add(lblAttachment);
            pnlContent.Controls.Add(picAttachment);
            pnlContent.Controls.Add(lblNoPicture);
            pnlContent.Controls.Add(progressEngagement);
            pnlContent.Controls.Add(lblEngagement);
            pnlContent.Controls.Add(btnSubmit);
            pnlContent.Controls.Add(btnBack);
            pnlContent.Location = new Point(40, 118);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(840, 610);
            pnlContent.TabIndex = 0;
            // 
            // lblSection
            // 
            lblSection.AutoSize = true;
            lblSection.Font = new Font("Segoe UI Semibold", 13F);
            lblSection.ForeColor = Color.FromArgb(30, 41, 59);
            lblSection.Location = new Point(36, 24);
            lblSection.Name = "lblSection";
            lblSection.Size = new Size(136, 30);
            lblSection.TabIndex = 0;
            lblSection.Text = "Issue Details";
            // 
            // picLocation
            // 
            picLocation.Location = new Point(36, 70);
            picLocation.Name = "picLocation";
            picLocation.Size = new Size(22, 22);
            picLocation.SizeMode = PictureBoxSizeMode.Zoom;
            picLocation.TabIndex = 1;
            picLocation.TabStop = false;
            // 
            // lblLocation
            // 
            lblLocation.AutoSize = true;
            lblLocation.Font = new Font("Segoe UI Semibold", 10.5F);
            lblLocation.ForeColor = Color.FromArgb(51, 65, 85);
            lblLocation.Location = new Point(64, 70);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(83, 25);
            lblLocation.TabIndex = 2;
            lblLocation.Text = "Location";
            // 
            // txtLocation
            // 
            txtLocation.BorderStyle = BorderStyle.FixedSingle;
            txtLocation.Font = new Font("Segoe UI", 11F);
            txtLocation.Location = new Point(36, 98);
            txtLocation.Name = "txtLocation";
            txtLocation.PlaceholderText = "e.g. Corner of Main & 5th Street";
            txtLocation.Size = new Size(768, 32);
            txtLocation.TabIndex = 3;
            // 
            // lblLocationError
            // 
            lblLocationError.AutoSize = true;
            lblLocationError.Font = new Font("Segoe UI", 9F);
            lblLocationError.ForeColor = Color.FromArgb(220, 38, 38);
            lblLocationError.Location = new Point(36, 132);
            lblLocationError.Name = "lblLocationError";
            lblLocationError.Size = new Size(0, 20);
            lblLocationError.TabIndex = 4;
            lblLocationError.Visible = false;
            // 
            // picCategory
            // 
            picCategory.Location = new Point(36, 162);
            picCategory.Name = "picCategory";
            picCategory.Size = new Size(22, 22);
            picCategory.SizeMode = PictureBoxSizeMode.Zoom;
            picCategory.TabIndex = 5;
            picCategory.TabStop = false;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Segoe UI Semibold", 10.5F);
            lblCategory.ForeColor = Color.FromArgb(51, 65, 85);
            lblCategory.Location = new Point(64, 162);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(88, 25);
            lblCategory.TabIndex = 6;
            lblCategory.Text = "Category";
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.Font = new Font("Segoe UI", 11F);
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Items.AddRange(new object[] { "Sanitation", "Water and Electricity", "Roads", "Utilities", "Other" });
            cmbCategory.Location = new Point(36, 190);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(768, 33);
            cmbCategory.TabIndex = 7;
            // 
            // lblCategoryError
            // 
            lblCategoryError.AutoSize = true;
            lblCategoryError.Font = new Font("Segoe UI", 9F);
            lblCategoryError.ForeColor = Color.FromArgb(220, 38, 38);
            lblCategoryError.Location = new Point(36, 225);
            lblCategoryError.Name = "lblCategoryError";
            lblCategoryError.Size = new Size(0, 20);
            lblCategoryError.TabIndex = 8;
            lblCategoryError.Visible = false;
            // 
            // picDescription
            // 
            picDescription.Location = new Point(36, 258);
            picDescription.Name = "picDescription";
            picDescription.Size = new Size(22, 22);
            picDescription.SizeMode = PictureBoxSizeMode.Zoom;
            picDescription.TabIndex = 9;
            picDescription.TabStop = false;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI Semibold", 10.5F);
            lblDescription.ForeColor = Color.FromArgb(51, 65, 85);
            lblDescription.Location = new Point(64, 258);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(108, 25);
            lblDescription.TabIndex = 10;
            lblDescription.Text = "Description";
            // 
            // rtbDescription
            // 
            rtbDescription.BorderStyle = BorderStyle.FixedSingle;
            rtbDescription.Font = new Font("Segoe UI", 11F);
            rtbDescription.Location = new Point(36, 286);
            rtbDescription.Name = "rtbDescription";
            rtbDescription.Size = new Size(768, 100);
            rtbDescription.TabIndex = 11;
            rtbDescription.Text = "";
            // 
            // lblDescriptionError
            // 
            lblDescriptionError.AutoSize = true;
            lblDescriptionError.Font = new Font("Segoe UI", 9F);
            lblDescriptionError.ForeColor = Color.FromArgb(220, 38, 38);
            lblDescriptionError.Location = new Point(36, 388);
            lblDescriptionError.Name = "lblDescriptionError";
            lblDescriptionError.Size = new Size(0, 20);
            lblDescriptionError.TabIndex = 12;
            lblDescriptionError.Visible = false;
            // 
            // btnAttach
            // 
            btnAttach.Cursor = Cursors.Hand;
            btnAttach.FlatAppearance.BorderSize = 0;
            btnAttach.FlatStyle = FlatStyle.Flat;
            btnAttach.Font = new Font("Segoe UI Semibold", 10.5F);
            btnAttach.Location = new Point(36, 420);
            btnAttach.Name = "btnAttach";
            btnAttach.Size = new Size(270, 42);
            btnAttach.TabIndex = 13;
            btnAttach.Text = "  Attach Image / Document";
            btnAttach.TextAlign = ContentAlignment.MiddleLeft;
            btnAttach.Click += btnAttach_Click;
            // 
            // lblAttachment
            // 
            lblAttachment.AutoSize = true;
            lblAttachment.Font = new Font("Segoe UI", 10F);
            lblAttachment.ForeColor = Color.FromArgb(100, 116, 139);
            lblAttachment.Location = new Point(320, 430);
            lblAttachment.Name = "lblAttachment";
            lblAttachment.Size = new Size(132, 23);
            lblAttachment.TabIndex = 14;
            lblAttachment.Text = "No file attached";
            // 
            // picAttachment
            // 
            picAttachment.BorderStyle = BorderStyle.FixedSingle;
            picAttachment.Location = new Point(36, 476);
            picAttachment.Name = "picAttachment";
            picAttachment.Size = new Size(140, 90);
            picAttachment.SizeMode = PictureBoxSizeMode.Zoom;
            picAttachment.TabIndex = 15;
            picAttachment.TabStop = false;
            picAttachment.Visible = false;
            // 
            // lblNoPicture
            // 
            lblNoPicture.AutoSize = true;
            lblNoPicture.Font = new Font("Segoe UI", 9.5F);
            lblNoPicture.ForeColor = Color.FromArgb(148, 163, 184);
            lblNoPicture.Location = new Point(190, 510);
            lblNoPicture.Name = "lblNoPicture";
            lblNoPicture.Size = new Size(146, 21);
            lblNoPicture.TabIndex = 16;
            lblNoPicture.Text = "No picture attached";
            // 
            // progressEngagement
            // 
            progressEngagement.Location = new Point(420, 490);
            progressEngagement.Maximum = 4;
            progressEngagement.Name = "progressEngagement";
            progressEngagement.Size = new Size(384, 12);
            progressEngagement.Style = ProgressBarStyle.Continuous;
            progressEngagement.TabIndex = 17;
            // 
            // lblEngagement
            // 
            lblEngagement.AutoSize = true;
            lblEngagement.Font = new Font("Segoe UI", 9.5F);
            lblEngagement.ForeColor = Color.FromArgb(71, 85, 105);
            lblEngagement.Location = new Point(420, 512);
            lblEngagement.Name = "lblEngagement";
            lblEngagement.Size = new Size(290, 21);
            lblEngagement.TabIndex = 18;
            lblEngagement.Text = "Let's get started! Fill in the details below.";
            // 
            // btnSubmit
            // 
            btnSubmit.Cursor = Cursors.Hand;
            btnSubmit.FlatAppearance.BorderSize = 0;
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.Font = new Font("Segoe UI Semibold", 11.5F);
            btnSubmit.Location = new Point(480, 555);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(160, 48);
            btnSubmit.TabIndex = 19;
            btnSubmit.Text = "Submit Issue";
            btnSubmit.Click += btnSubmit_Click;
            // 
            // btnBack
            // 
            btnBack.Cursor = Cursors.Hand;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI Semibold", 11F);
            btnBack.ImageAlign = ContentAlignment.MiddleLeft;
            btnBack.Location = new Point(660, 555);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(140, 48);
            btnBack.TabIndex = 20;
            btnBack.Text = "  Back";
            btnBack.TextAlign = ContentAlignment.MiddleLeft;
            btnBack.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBack.Click += btnBack_Click;
            // 
            // ReportIssuesForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            ClientSize = new Size(920, 770);
            Controls.Add(pnlContent);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 9.5F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "ReportIssuesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Report an Issue • Municipal Services Portal";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picHeaderLogo).EndInit();
            pnlContent.ResumeLayout(false);
            pnlContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLocation).EndInit();
            ((System.ComponentModel.ISupportInitialize)picCategory).EndInit();
            ((System.ComponentModel.ISupportInitialize)picDescription).EndInit();
            ((System.ComponentModel.ISupportInitialize)picAttachment).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private PictureBox picHeaderLogo;
        private Label lblHeaderTitle;
        private Label lblHeaderSubtitle;
        private Panel pnlContent;
        private Label lblSection;

        private PictureBox picLocation;
        private Label lblLocation;
        private TextBox txtLocation;
        private Label lblLocationError;

        private PictureBox picCategory;
        private Label lblCategory;
        private ComboBox cmbCategory;
        private Label lblCategoryError;

        private PictureBox picDescription;
        private Label lblDescription;
        private RichTextBox rtbDescription;
        private Label lblDescriptionError;

        private Button btnAttach;
        private Label lblAttachment;
        private PictureBox picAttachment;
        private Label lblNoPicture;
        private ProgressBar progressEngagement;
        private Label lblEngagement;
        private Button btnSubmit;
        private Button btnBack;
    }
}