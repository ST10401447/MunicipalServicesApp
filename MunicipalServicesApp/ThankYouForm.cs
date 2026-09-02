using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class ThankYouForm : Form
    {
        public ThankYouForm(Issue submittedIssue)
        {
            InitializeComponent();
            ApplyModernTheme();
            ApplyRoundedCorners();

            lblSummary.Text = $"Category: {submittedIssue.Category}\nLocation: {submittedIssue.Location}";
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
            picSuccess.Image = AppTheme.ResizeIcon(LoadIcon("check.png"), 70);

            // Icon size 18 + padding works best
            btnBackToMenuFromThanks.Image = AppTheme.ResizeIcon(LoadIcon("left-arrow.png"), 18);

            pnlContent.Paint += PnlContent_Paint;

            StylePrimaryButton(btnViewFromThanks, AppTheme.PrimaryBlue);
            StyleSecondaryButton(btnBackToMenuFromThanks);
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
            MakeRounded(btnBackToMenuFromThanks, 12);
            MakeRounded(btnViewFromThanks, 12);
        }

        private void MakeRounded(Control ctrl, int radius)
        {
            if (ctrl == null || ctrl.Width <= 0 || ctrl.Height <= 0) return;
            using var path = AppTheme.CreateRoundedRectangle(
                new Rectangle(0, 0, ctrl.Width, ctrl.Height), radius);
            ctrl.Region = new Region(path);
        }

        private void btnBackToMenuFromThanks_Click(object sender, EventArgs e)
        {
            var main = new Form1();
            main.Show();
            this.Close();
        }

        private void btnViewFromThanks_Click(object sender, EventArgs e)
        {
            var viewForm = new ViewIssuesForm();
            viewForm.Show();
            this.Close();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            ApplyRoundedCorners();
        }
    }
}