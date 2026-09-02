using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
namespace MunicipalServicesApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ApplyModernTheme();
            ApplyRoundedCorners();
            WireHoverEffects();
        }
        private void ApplyModernTheme()
        {
            this.BackColor = AppTheme.BackgroundGray;
            pnlHeader.BackColor = AppTheme.PrimaryBlue;
            pnlContent.BackColor = AppTheme.SurfaceWhite;
            pnlContent.Paint += PnlContent_Paint;

            StylePrimaryButton(btnReportIssues, AppTheme.PrimaryBlue, AppTheme.PrimaryBlueLight);
            StylePrimaryButton(btnViewIssues, AppTheme.AccentTeal, AppTheme.AccentTealLight);
            StyleDisabledButton(btnLocalEvents);
            StyleDisabledButton(btnServiceStatus);

            picHeaderLogo.Image = AppTheme.ResizeIcon(Resources.city_hall, 44);
            picHeaderLogo.BackColor = Color.Transparent;
            btnReportIssues.Image = AppTheme.ResizeIcon(Resources.megaphone, 24);
            btnViewIssues.Image = AppTheme.ResizeIcon(Resources.task_list, 24);
            btnLocalEvents.Image = AppTheme.ResizeIcon(Resources.calendar, 24);
            btnServiceStatus.Image = AppTheme.ResizeIcon(Resources.time_tracking, 24);

            foreach (var btn in new[] { btnReportIssues, btnViewIssues, btnLocalEvents, btnServiceStatus })
            {
                btn.ImageAlign = ContentAlignment.MiddleLeft;
                btn.TextImageRelation = TextImageRelation.ImageBeforeText;
                btn.TextAlign = ContentAlignment.MiddleLeft;
                btn.Padding = new Padding(22, 0, 16, 0);
            }
        }
        private void PnlContent_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (var shadow = new SolidBrush(Color.FromArgb(28, 0, 0, 0)))
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
        private void StylePrimaryButton(Button btn, Color accent, Color lightBg)
        {
            btn.BackColor = lightBg;
            btn.ForeColor = accent;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = ControlPaint.Light(lightBg, 0.08f);
            btn.FlatAppearance.MouseDownBackColor = ControlPaint.Dark(lightBg, 0.04f);
            btn.Font = new Font("Segoe UI Semibold", 11.5f);
            btn.Cursor = Cursors.Hand;
        }
        private void StyleDisabledButton(Button btn)
        {
            btn.BackColor = AppTheme.DisabledBg;
            btn.ForeColor = AppTheme.DisabledText;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = AppTheme.DisabledBg;
            btn.FlatAppearance.MouseDownBackColor = AppTheme.DisabledBg;
            btn.Cursor = Cursors.Default;
            btn.Font = new Font("Segoe UI", 11f);
        }
        private void ApplyRoundedCorners()
        {
            MakeRounded(pnlContent, 16);
            MakeRounded(btnReportIssues, 14);
            MakeRounded(btnViewIssues, 14);
            MakeRounded(btnLocalEvents, 14);
            MakeRounded(btnServiceStatus, 14);
        }
        private void MakeRounded(Control ctrl, int radius)
        {
            if (ctrl == null || ctrl.Width <= 0 || ctrl.Height <= 0) return;
            using var path = AppTheme.CreateRoundedRectangle(
                new Rectangle(0, 0, ctrl.Width, ctrl.Height), radius);
            ctrl.Region = new Region(path);
        }
        private void WireHoverEffects()
        {
            AddHover(btnReportIssues, AppTheme.PrimaryBlueLight, Color.FromArgb(210, 230, 255));
            AddHover(btnViewIssues, AppTheme.AccentTealLight, Color.FromArgb(190, 245, 235));
        }
        private void AddHover(Button btn, Color normal, Color hover)
        {
            btn.MouseEnter += (s, e) => btn.BackColor = hover;
            btn.MouseLeave += (s, e) => btn.BackColor = normal;
        }
        private void btnReportIssues_Click(object sender, EventArgs e)
        {
            try
            {
                var reportForm = new ReportIssuesForm();
                reportForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open the Report Issues form.\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnViewIssues_Click(object sender, EventArgs e)
        {
            try
            {
                var viewForm = new ViewIssuesForm();
                viewForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open the View Issues form.\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            Application.Exit();
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (pnlContent != null)
                ApplyRoundedCorners();
        }

      
    }
}