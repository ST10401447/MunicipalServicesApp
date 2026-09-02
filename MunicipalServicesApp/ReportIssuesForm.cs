using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class ReportIssuesForm : Form
    {
        private string attachedFilePath = string.Empty;

        public ReportIssuesForm()
        {
            InitializeComponent();
            ApplyModernTheme();
            ApplyRoundedCorners();
            WireEvents();
        }

        private void ApplyModernTheme()
        {
            this.BackColor = AppTheme.BackgroundGray;

            // Robust icon loader
            Image LoadIcon(string fileName)
            {
                string[] possiblePaths =
                {
                    Path.Combine(Application.StartupPath, "Resources", fileName),
                    Path.Combine(Application.StartupPath, fileName),
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", fileName),
                    Path.Combine(Directory.GetCurrentDirectory(), "Resources", fileName)
                };

                foreach (string path in possiblePaths)
                {
                    if (File.Exists(path))
                    {
                        try { return Image.FromFile(path); }
                        catch { }
                    }
                }
                return null;
            }

            picHeaderLogo.Image = AppTheme.ResizeIcon(LoadIcon("city-hall.png"), 44);
            picLocation.Image = AppTheme.ResizeIcon(LoadIcon("pin.png"), 20);
            picCategory.Image = AppTheme.ResizeIcon(LoadIcon("price-tag.png"), 20);
            picDescription.Image = AppTheme.ResizeIcon(LoadIcon("task-list.png"), 20);

            // Back button icon
            btnBack.Image = AppTheme.ResizeIcon(LoadIcon("left-arrow.png"), 18);

            pnlContent.Paint += PnlContent_Paint;

            StylePrimaryButton(btnSubmit, AppTheme.PrimaryBlue);
            StyleSecondaryButton(btnBack);
            StyleSecondaryButton(btnAttach);
            btnAttach.BackColor = Color.FromArgb(241, 245, 249);
            btnAttach.ForeColor = AppTheme.PrimaryBlue;
        }

        private void PnlContent_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (var shadow = new SolidBrush(Color.FromArgb(25, 0, 0, 0)))
            {
                var shadowRect = new Rectangle(6, 8, pnlContent.Width - 12, pnlContent.Height - 12);
                using var path = AppTheme.CreateRoundedRectangle(shadowRect, 18);
                g.FillPath(shadow, path);
            }

            using (var brush = new SolidBrush(AppTheme.SurfaceWhite))
            {
                var rect = new Rectangle(0, 0, pnlContent.Width - 1, pnlContent.Height - 1);
                using var path = AppTheme.CreateRoundedRectangle(rect, 16);
                g.FillPath(brush, path);
            }

            using (var pen = new Pen(AppTheme.BorderGray, 1))
            {
                var rect = new Rectangle(0, 0, pnlContent.Width - 1, pnlContent.Height - 1);
                using var path = AppTheme.CreateRoundedRectangle(rect, 16);
                g.DrawPath(pen, path);
            }
        }

        private void StylePrimaryButton(Button btn, Color accent)
        {
            btn.BackColor = accent;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = ControlPaint.Light(accent, 0.12f);
            btn.FlatAppearance.MouseDownBackColor = ControlPaint.Dark(accent, 0.08f);
            btn.Cursor = Cursors.Hand;
        }

        private void StyleSecondaryButton(Button btn)
        {
            btn.BackColor = Color.FromArgb(241, 245, 249);
            btn.ForeColor = AppTheme.TextPrimary;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(226, 232, 240);
            btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(203, 213, 225);
            btn.Cursor = Cursors.Hand;
        }

        private void ApplyRoundedCorners()
        {
            MakeRounded(pnlContent, 16);
            MakeRounded(btnSubmit, 12);
            MakeRounded(btnBack, 12);
            MakeRounded(btnAttach, 10);
        }

        private void MakeRounded(Control ctrl, int radius)
        {
            if (ctrl == null || ctrl.Width <= 0 || ctrl.Height <= 0) return;
            using var path = AppTheme.CreateRoundedRectangle(
                new Rectangle(0, 0, ctrl.Width, ctrl.Height), radius);
            ctrl.Region = new Region(path);
        }

        private void WireEvents()
        {
            txtLocation.TextChanged += (s, e) =>
            {
                lblLocationError.Visible = false;
                UpdateEngagement(s, e);
            };
            cmbCategory.SelectedIndexChanged += (s, e) =>
            {
                lblCategoryError.Visible = false;
                UpdateEngagement(s, e);
            };
            rtbDescription.TextChanged += (s, e) =>
            {
                lblDescriptionError.Visible = false;
                UpdateEngagement(s, e);
            };
        }

        private void UpdateEngagement(object sender, EventArgs e)
        {
            int progress = 0;
            if (!string.IsNullOrWhiteSpace(txtLocation.Text)) progress++;
            if (cmbCategory.SelectedItem != null) progress++;
            if (!string.IsNullOrWhiteSpace(rtbDescription.Text)) progress++;
            if (!string.IsNullOrEmpty(attachedFilePath)) progress++;

            progressEngagement.Value = progress;

            lblEngagement.Text = progress switch
            {
                0 => "Let's get started! Fill in the details below.",
                1 => "Great start! Keep going.",
                2 => "You're halfway there!",
                3 => "Almost done — attach a file if you have one.",
                4 => "All set! Click Submit to report your issue.",
                _ => ""
            };
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog
            {
                Filter = "Image or Document|*.jpg;*.jpeg;*.png;*.pdf;*.docx;*.txt",
                Title = "Select a file to attach"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                attachedFilePath = ofd.FileName;
                lblAttachment.Text = "Attached: " + Path.GetFileName(attachedFilePath);

                string ext = Path.GetExtension(attachedFilePath).ToLower();
                if (ext is ".jpg" or ".jpeg" or ".png")
                {
                    try
                    {
                        picAttachment.Image = Image.FromFile(attachedFilePath);
                        picAttachment.Visible = true;
                        lblNoPicture.Visible = false;
                    }
                    catch
                    {
                        picAttachment.Visible = false;
                        lblNoPicture.Visible = true;
                        lblNoPicture.Text = "Could not load preview";
                    }
                }
                else
                {
                    picAttachment.Image = null;
                    picAttachment.Visible = false;
                    lblNoPicture.Visible = true;
                    lblNoPicture.Text = "Document attached (no preview)";
                }

                UpdateEngagement(sender, e);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            ClearErrors();
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                ShowError(lblLocationError, "Please enter the location of the issue.");
                isValid = false;
            }

            if (cmbCategory.SelectedItem == null)
            {
                ShowError(lblCategoryError, "Please select a category.");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(rtbDescription.Text))
            {
                ShowError(lblDescriptionError, "Please provide a description of the issue.");
                isValid = false;
            }

            if (!isValid) return;

            var newIssue = new Issue(
                txtLocation.Text.Trim(),
                cmbCategory.SelectedItem.ToString(),
                rtbDescription.Text.Trim(),
                attachedFilePath
            );

            IssueManager.AddIssue(newIssue);

            var thankYouForm = new ThankYouForm(newIssue);
            thankYouForm.Show();
            this.Hide();
        }

        private void ShowError(Label errorLabel, string message)
        {
            errorLabel.Text = message;
            errorLabel.Visible = true;
        }

        private void ClearErrors()
        {
            lblLocationError.Visible = false;
            lblCategoryError.Visible = false;
            lblDescriptionError.Visible = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var main = new Form1();
            main.Show();
            this.Close();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            ApplyRoundedCorners();
        }
    }
}