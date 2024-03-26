using System;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Crycker.Helper
{
    static class TaskbarIconHelper
    {
        public static NotifyIcon notifyIcon;

        public static bool DarkMode { get; set; }
        public static bool Highlight { get; set; }

        private static readonly Font font;

        static TaskbarIconHelper()
        {
            var settings = Settings.UserSettings.Load();
            font = new Font(settings.FontName, settings.FontSize, settings.FontStyleBold ? FontStyle.Bold : FontStyle.Regular);
            if (String.Compare(settings.FontName, font.Name, StringComparison.InvariantCultureIgnoreCase) != 0)
            {
                Logger.Warning($"Font '{settings.FontName}' not found, '{font.Name}' selected. Backing down to 'Tahoma'.");
                font = new Font("Tahoma", 7, FontStyle.Bold);
            }
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool DestroyIcon(IntPtr handle);

        private static IntPtr lastIcon;

        public static void SetPrice(decimal lastPrice, decimal previousPrice, string coin, string currency, string provider, DateTime lastUpdated)
        {
            DestroyIcon(lastIcon);
            var percentChange = 0.0M;
            var brush = new SolidBrush(DarkMode ? Color.White : Color.Black);

            if (lastPrice > 0 && Highlight)
            {
                percentChange = (lastPrice - previousPrice) / lastPrice * 100;
                Logger.Info($"Change since last: {percentChange:N2}%");
                if (percentChange != 0)
                {
                    Color priceColor = (percentChange >= 0) ? Color.Green : Color.OrangeRed;
                    brush.Dispose();
                    brush = new SolidBrush(priceColor);
                    var settings = Settings.UserSettings.Load();
                    var absolutePercent = Math.Abs(percentChange);                    
                    if (settings.PercentageNotification > 0 && absolutePercent > settings.PercentageNotification)
                        notifyIcon.ShowBalloonTip(5000, "Crycker", $"{settings.Coin} {(percentChange > 0 ? "rose above" : "fell under")} {absolutePercent:N2}% in the last {settings.RefreshInterval} seconds!", ToolTipIcon.Info);
                }
            }

            using (var bitmap = new Bitmap(16, 16))
            using (var graphics = Graphics.FromImage(bitmap))
            {
                // graphics.FillRectangle(Brushes.White, new Rectangle(0, 0, 16, 16));

                string line1;
                string line2;

                if (lastPrice == 0)
                {
                    line1 = "?";
                    line2 = "";
                }
                else if (lastPrice < 1)
                {
                    var s = lastPrice.ToString("F3").Split(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]);
                    line1 = s[0];
                    line2 = s[1];
                }
                else if (lastPrice >= 1000)
                {
                    var s = lastPrice.ToString("F0");
                    if (s.Length > 5) s = s.Substring(0, 6);
                    line1 = s.Substring(0, s.Length - 3) + "k";
                    line2 = s.Substring(s.Length - 3, 3);
                }
                else
                {
                    var s = lastPrice.ToString("F2").Split(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]);
                    line1 = s[0];
                    line2 = s[1];
                }

                var m = graphics.MeasureString(line1, font);
                var w2 = (int)Math.Round(m.Width / 2);
                var h2 = (int)Math.Round(m.Height / 2);
                graphics.DrawString(line1, font, brush, bitmap.Size.Width / 2 - w2, -3 + bitmap.Size.Height / 2 - h2);

                m = graphics.MeasureString(line2, font);
                w2 = (int)Math.Round(m.Width / 2);
                h2 = (int)Math.Round(m.Height / 2);
                graphics.DrawString(line2, font, brush, bitmap.Size.Width / 2 - w2, 5 + bitmap.Size.Height / 2 - h2);

                lastIcon = bitmap.GetHicon();
                var icon = Icon.FromHandle(lastIcon);
                notifyIcon.Icon = icon;                
            }
            brush.Dispose();
            notifyIcon.Text = $"{provider} {coin}/{currency}: {lastPrice} ({percentChange:N2}%) @ {lastUpdated.ToLongTimeString()}";
        }        
    }
}
