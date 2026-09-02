using System.Drawing;
using System.Drawing.Drawing2D;

namespace MunicipalServicesApp
{
    public static class AppTheme
    {
        // Core palette
        public static readonly Color BackgroundGray = Color.FromArgb(241, 245, 249); // slate-100
        public static readonly Color SurfaceWhite = Color.White;
        public static readonly Color PrimaryBlue = Color.FromArgb(15, 76, 129);   // deep professional blue
        public static readonly Color PrimaryBlueLight = Color.FromArgb(226, 239, 255);
        public static readonly Color AccentTeal = Color.FromArgb(13, 148, 136);
        public static readonly Color AccentTealLight = Color.FromArgb(204, 251, 241);
        public static readonly Color BorderGray = Color.FromArgb(226, 232, 240);
        public static readonly Color DisabledBg = Color.FromArgb(248, 250, 252);
        public static readonly Color DisabledText = Color.FromArgb(148, 163, 184);
        public static readonly Color TextPrimary = Color.FromArgb(30, 41, 59);
        public static readonly Color TextSecondary = Color.FromArgb(100, 116, 139);

        public static GraphicsPath CreateRoundedRectangle(Rectangle bounds, int radius)
        {
            int d = radius * 2;
            var path = new GraphicsPath();
            path.AddArc(bounds.X, bounds.Y, d, d, 180, 90);
            path.AddArc(bounds.Right - d, bounds.Y, d, d, 270, 90);
            path.AddArc(bounds.Right - d, bounds.Bottom - d, d, d, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        public static Image ResizeIcon(Image original, int size)
        {
            if (original == null) return null;
            var bmp = new Bitmap(size, size);
            using var g = Graphics.FromImage(bmp);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.DrawImage(original, 0, 0, size, size);
            return bmp;
        }
    }
}