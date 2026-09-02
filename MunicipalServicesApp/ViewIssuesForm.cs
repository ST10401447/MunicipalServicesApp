using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class ViewIssuesForm : Form
    {
        public ViewIssuesForm()
        {
            InitializeComponent();
            ApplyModernTheme();
            ApplyRoundedCorners();
            LoadIssueList();
        }

        private void ApplyModernTheme()
        {
            this.BackColor = AppTheme.BackgroundGray;

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
            picLocation.Image = AppTheme.ResizeIcon(LoadIcon("pin.png"), 18);
            picCategory.Image = AppTheme.ResizeIcon(LoadIcon("price-tag.png"), 18);
            picDescription.Image = AppTheme.ResizeIcon(LoadIcon("task-list.png"), 18);
            btnBackFromView.Image = AppTheme.ResizeIcon(LoadIcon("left-arrow.png"), 18);

            pnlContent.Paint += PnlContent_Paint;
            StyleSecondaryButton(btnBackFromView);
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
            MakeRounded(btnBackFromView, 12);
        }

        private void MakeRounded(Control ctrl, int radius)
        {
            if (ctrl == null || ctrl.Width <= 0 || ctrl.Height <= 0) return;
            using var path = AppTheme.CreateRoundedRectangle(
                new Rectangle(0, 0, ctrl.Width, ctrl.Height), radius);
            ctrl.Region = new Region(path);
        }

        private void LoadIssueList()
        {
            lstIssues.Items.Clear();

            if (IssueManager.Issues.Count == 0)
            {
                lstIssues.Items.Add("No issues have been reported yet.");
                ClearDetails();
                return;
            }

            // Show ALL issues that have been reported (they are never deleted)
            for (int i = 0; i < IssueManager.Issues.Count; i++)
            {
                Issue issue = IssueManager.Issues[i];
                lstIssues.Items.Add($"{i + 1}. {issue.Category} - {issue.Location}");
            }

            lstIssues.SelectedIndex = 0;
        }

        private void lstIssues_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IssueManager.Issues.Count == 0 || lstIssues.SelectedIndex < 0)
                return;

            Issue selected = IssueManager.Issues[lstIssues.SelectedIndex];

            lblDetailLocation.Text = selected.Location;
            lblDetailCategory.Text = selected.Category;
            lblDetailDescription.Text = selected.Description;

            if (string.IsNullOrEmpty(selected.AttachmentPath))
            {
                lblDetailFileName.Text = "No file was uploaded";
                picDetailImage.Image = null;
                picDetailImage.Visible = false;
                lblNoFileDetail.Visible = true;
                lblNoFileDetail.Text = "No picture attached";
            }
            else
            {
                string fileName = Path.GetFileName(selected.AttachmentPath);
                lblDetailFileName.Text = fileName;

                string ext = Path.GetExtension(selected.AttachmentPath).ToLower();
                if (ext is ".jpg" or ".jpeg" or ".png")
                {
                    try
                    {
                        picDetailImage.Image = Image.FromFile(selected.AttachmentPath);
                        picDetailImage.Visible = true;
                        lblNoFileDetail.Visible = false;
                    }
                    catch
                    {
                        picDetailImage.Image = null;
                        picDetailImage.Visible = false;
                        lblNoFileDetail.Visible = true;
                        lblNoFileDetail.Text = "Image could not be loaded";
                    }
                }
                else
                {
                    picDetailImage.Image = null;
                    picDetailImage.Visible = false;
                    lblNoFileDetail.Visible = true;
                    lblNoFileDetail.Text = "Document attached (no preview)";
                }
            }
        }

        private void ClearDetails()
        {
            lblDetailLocation.Text = "-";
            lblDetailCategory.Text = "-";
            lblDetailDescription.Text = "-";
            lblDetailFileName.Text = "No file was uploaded";
            picDetailImage.Image = null;
            picDetailImage.Visible = false;
            lblNoFileDetail.Visible = true;
            lblNoFileDetail.Text = "No picture attached";
        }

        private void btnBackFromView_Click(object sender, EventArgs e)
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