using System;
using System.Drawing;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    partial class LocalEventsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblTitle = new Label();
            btnBack = new Button();
            lblAnnouncement = new Label();
            btnDismiss = new Button();
            lblCapSearch = new Label();
            lblCapCategory = new Label();
            chkDate = new CheckBox();
            txtSearch = new TextBox();
            cboCategory = new ComboBox();
            dtpDate = new DateTimePicker();
            btnSearch = new Button();
            btnClear = new Button();
            lvEvents = new ListView();
            lblStatus = new Label();
            lblCapDetails = new Label();
            lblDetails = new Label();
            lblCapRecs = new Label();
            lstRecs = new ListBox();
            lblCapRecent = new Label();
            lstRecent = new ListBox();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(13, 71, 125);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(btnBack);
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1060, 70);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Semibold", 18F);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(479, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Local Events and Announcements";
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.White;
            btnBack.Cursor = Cursors.Hand;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.ForeColor = Color.FromArgb(13, 71, 125);
            btnBack.Location = new Point(890, 18);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(150, 34);
            btnBack.TabIndex = 1;
            btnBack.Text = "Back to Menu";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // lblAnnouncement
            // 
            lblAnnouncement.BackColor = Color.FromArgb(254, 243, 199);
            lblAnnouncement.Font = new Font("Segoe UI Semibold", 9.5F);
            lblAnnouncement.Location = new Point(0, 70);
            lblAnnouncement.Name = "lblAnnouncement";
            lblAnnouncement.Padding = new Padding(20, 0, 0, 0);
            lblAnnouncement.Size = new Size(895, 45);
            lblAnnouncement.TabIndex = 1;
            lblAnnouncement.Text = "Announcement";
            lblAnnouncement.TextAlign = ContentAlignment.MiddleLeft;
            lblAnnouncement.UseMnemonic = false;
            // 
            // btnDismiss
            // 
            btnDismiss.BackColor = Color.White;
            btnDismiss.Cursor = Cursors.Hand;
            btnDismiss.FlatAppearance.BorderSize = 0;
            btnDismiss.FlatStyle = FlatStyle.Flat;
            btnDismiss.ForeColor = Color.FromArgb(30, 41, 59);
            btnDismiss.Location = new Point(905, 76);
            btnDismiss.Name = "btnDismiss";
            btnDismiss.Size = new Size(140, 32);
            btnDismiss.TabIndex = 2;
            btnDismiss.Text = "Dismiss";
            btnDismiss.UseVisualStyleBackColor = false;
            btnDismiss.Click += btnDismiss_Click;
            // 
            // lblCapSearch
            // 
            lblCapSearch.AutoSize = true;
            lblCapSearch.Font = new Font("Segoe UI Semibold", 9.5F);
            lblCapSearch.ForeColor = Color.FromArgb(13, 71, 125);
            lblCapSearch.Location = new Point(20, 122);
            lblCapSearch.Name = "lblCapSearch";
            lblCapSearch.Size = new Size(59, 21);
            lblCapSearch.TabIndex = 3;
            lblCapSearch.Text = "Search";
            // 
            // lblCapCategory
            // 
            lblCapCategory.AutoSize = true;
            lblCapCategory.Font = new Font("Segoe UI Semibold", 9.5F);
            lblCapCategory.ForeColor = Color.FromArgb(13, 71, 125);
            lblCapCategory.Location = new Point(290, 122);
            lblCapCategory.Name = "lblCapCategory";
            lblCapCategory.Size = new Size(78, 21);
            lblCapCategory.TabIndex = 4;
            lblCapCategory.Text = "Category";
            // 
            // chkDate
            // 
            chkDate.AutoSize = true;
            chkDate.Cursor = Cursors.Hand;
            chkDate.Font = new Font("Segoe UI Semibold", 9.5F);
            chkDate.ForeColor = Color.FromArgb(13, 71, 125);
            chkDate.Location = new Point(490, 120);
            chkDate.Name = "chkDate";
            chkDate.Size = new Size(128, 25);
            chkDate.TabIndex = 5;
            chkDate.Text = "Filter by date";
            chkDate.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(20, 145);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(250, 29);
            txtSearch.TabIndex = 6;
            // 
            // cboCategory
            // 
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory.FormattingEnabled = true;
            cboCategory.Location = new Point(290, 145);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(180, 29);
            cboCategory.TabIndex = 7;
            // 
            // dtpDate
            // 
            dtpDate.CustomFormat = "ddd d MMM yyyy";
            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.Location = new Point(490, 145);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(170, 29);
            dtpDate.TabIndex = 8;
            dtpDate.ValueChanged += dtpDate_ValueChanged;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(0, 120, 212);
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(680, 143);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(100, 32);
            btnSearch.TabIndex = 9;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(226, 232, 240);
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.ForeColor = Color.FromArgb(30, 41, 59);
            btnClear.Location = new Point(790, 143);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(90, 32);
            btnClear.TabIndex = 10;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // lvEvents
            // 
            lvEvents.FullRowSelect = true;
            lvEvents.Location = new Point(20, 190);
            lvEvents.MultiSelect = false;
            lvEvents.Name = "lvEvents";
            lvEvents.Size = new Size(660, 470);
            lvEvents.TabIndex = 11;
            lvEvents.UseCompatibleStateImageBehavior = false;
            lvEvents.View = View.Details;
            lvEvents.SelectedIndexChanged += lvEvents_SelectedIndexChanged;
            // 
            // lblStatus
            // 
            lblStatus.ForeColor = Color.FromArgb(100, 116, 139);
            lblStatus.Location = new Point(20, 665);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(660, 25);
            lblStatus.TabIndex = 12;
            // 
            // lblCapDetails
            // 
            lblCapDetails.AutoSize = true;
            lblCapDetails.Font = new Font("Segoe UI Semibold", 9.5F);
            lblCapDetails.ForeColor = Color.FromArgb(13, 71, 125);
            lblCapDetails.Location = new Point(700, 190);
            lblCapDetails.Name = "lblCapDetails";
            lblCapDetails.Size = new Size(102, 21);
            lblCapDetails.TabIndex = 13;
            lblCapDetails.Text = "Event details";
            // 
            // lblDetails
            // 
            lblDetails.BackColor = Color.White;
            lblDetails.BorderStyle = BorderStyle.FixedSingle;
            lblDetails.Location = new Point(700, 213);
            lblDetails.Name = "lblDetails";
            lblDetails.Padding = new Padding(8);
            lblDetails.Size = new Size(340, 190);
            lblDetails.TabIndex = 14;
            lblDetails.Text = "Select an event";
            // 
            // lblCapRecs
            // 
            lblCapRecs.AutoSize = true;
            lblCapRecs.Font = new Font("Segoe UI Semibold", 9.5F);
            lblCapRecs.ForeColor = Color.FromArgb(13, 71, 125);
            lblCapRecs.Location = new Point(700, 415);
            lblCapRecs.Name = "lblCapRecs";
            lblCapRecs.Size = new Size(179, 21);
            lblCapRecs.TabIndex = 15;
            lblCapRecs.Text = "Recommended for you";
            // 
            // lstRecs
            // 
            lstRecs.FormattingEnabled = true;
            lstRecs.IntegralHeight = false;
            lstRecs.Location = new Point(700, 438);
            lstRecs.Name = "lstRecs";
            lstRecs.Size = new Size(340, 110);
            lstRecs.TabIndex = 16;
            lstRecs.SelectedIndexChanged += lstRecs_SelectedIndexChanged;
            // 
            // lblCapRecent
            // 
            lblCapRecent.AutoSize = true;
            lblCapRecent.Font = new Font("Segoe UI Semibold", 9.5F);
            lblCapRecent.ForeColor = Color.FromArgb(13, 71, 125);
            lblCapRecent.Location = new Point(700, 560);
            lblCapRecent.Name = "lblCapRecent";
            lblCapRecent.Size = new Size(129, 21);
            lblCapRecent.TabIndex = 17;
            lblCapRecent.Text = "Recently viewed";
            // 
            // lstRecent
            // 
            lstRecent.FormattingEnabled = true;
            lstRecent.IntegralHeight = false;
            lstRecent.Location = new Point(700, 583);
            lstRecent.Name = "lstRecent";
            lstRecent.Size = new Size(340, 107);
            lstRecent.TabIndex = 18;
            lstRecent.SelectedIndexChanged += lstRecent_SelectedIndexChanged;
            // 
            // LocalEventsForm
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(241, 245, 249);
            ClientSize = new Size(1060, 700);
            Controls.Add(pnlHeader);
            Controls.Add(lblAnnouncement);
            Controls.Add(btnDismiss);
            Controls.Add(lblCapSearch);
            Controls.Add(lblCapCategory);
            Controls.Add(chkDate);
            Controls.Add(txtSearch);
            Controls.Add(cboCategory);
            Controls.Add(dtpDate);
            Controls.Add(btnSearch);
            Controls.Add(btnClear);
            Controls.Add(lvEvents);
            Controls.Add(lblStatus);
            Controls.Add(lblCapDetails);
            Controls.Add(lblDetails);
            Controls.Add(lblCapRecs);
            Controls.Add(lstRecs);
            Controls.Add(lblCapRecent);
            Controls.Add(lstRecent);
            Font = new Font("Segoe UI", 9.5F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "LocalEventsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Local Events and Announcements";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Panel pnlHeader;
        private Label lblTitle;
        private Button btnBack;
        private Label lblAnnouncement;
        private Button btnDismiss;
        private Label lblCapSearch;
        private Label lblCapCategory;
        private CheckBox chkDate;
        private TextBox txtSearch;
        private ComboBox cboCategory;
        private DateTimePicker dtpDate;
        private Button btnSearch;
        private Button btnClear;
        private ListView lvEvents;
        private Label lblStatus;
        private Label lblCapDetails;
        private Label lblDetails;
        private Label lblCapRecs;
        private ListBox lstRecs;
        private Label lblCapRecent;
        private ListBox lstRecent;
    }
}
