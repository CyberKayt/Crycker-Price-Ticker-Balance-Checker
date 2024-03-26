namespace DaddyRecoveryBuilder.Design
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    public class NewCheckBox : CheckBox
    {
        public NewCheckBox()
        {
            Translator = "#548E19";
            SetCheckColor("#2F333A");
            SnColor2 = ColorTranslator.FromHtml(Translator);
            SnColor3 = ColorTranslator.FromHtml("#c4c6ca");
            SnColor4 = ColorTranslator.FromHtml("#999999");
            SnColor5 = ColorTranslator.FromHtml("#babbbd");
            sTimer = new Timer
            {
                Interval = 0x28
            };
            Dia = 0xE;
            Vert = 0x3;
            DoubleBuffered = true;
            BackColor = Color.Transparent;
            TabStop = false;
            sTimer.Tick += Timer_0_Tick;
        }
        private void Timer_0_Tick(object sender, EventArgs e)
        {
            if (!Checked)
            {
                if (Horiz > 0)
                {
                    Horiz -= 25;
                    Invalidate();
                    if (Dia < 14)
                    {
                        Dia += 2;
                        Invalidate();
                    }
                    if (Vert > 3)
                    {
                        Vert--;
                        Invalidate();
                    }
                }
            }
            else
            {
                if (Horiz < 0xFA)
                {
                    Horiz += 0x19;
                    Invalidate();
                    if (Dia > 0x0)
                    {
                        Dia -= 0x2;
                        Invalidate();
                    }
                    if (Vert < 0xA)
                    {
                        Vert++;
                        Invalidate();
                        return;
                    }
                }
            }
        }
        static NewCheckBox() => point_0 = new Point[]
        {
           new Point(0x3, 0x8),
           new Point(0x7, 0xC),
           new Point(0xE, 0x5)
        };

        public string GetCheckColor() => Translator;

        public void SetCheckColor(string value)
        {
            Translator = value;
            Invalidate();
        }

        protected override void OnResize(EventArgs e)
        {
            Height = 0x14;
            Width = 0x14 + (int)CreateGraphics().MeasureString(Text, Font).Width;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            sTimer.Start();
        }

        private Bitmap GetDrawLike()
        {
            var bitmap = new Bitmap(0x10, 0x10);
            using var graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.Transparent);
            graphics.DrawLines(new Pen(new SolidBrush(Color.FromArgb(Horiz, 0xFF, 0xFF, 0xFF)), 0x2), point_0); // Like color 255  // 0x2 check mark

            return bitmap;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics graphics = pevent.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.Clear(Parent.BackColor);
            SnColor = ColorTranslator.FromHtml(Translator);
            using var solidBrush = new SolidBrush(Enabled ? (Checked ? SnColor : SnColor2) : SnColor3);
            using var pen = new Pen(solidBrush.Color);
            GraphicsPath path = GraphBox.Graph1(0x1, 0x1, 0x11, 0x11, 0x1);
            graphics.FillPath(solidBrush, path);
            graphics.DrawPath(pen, path);
            graphics.SmoothingMode = SmoothingMode.None; // 20262C  32,38,44
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(32, 38, 44)), Vert, Vert, Dia, Dia); // 0x3E, 0x46, 0x52 (окошко)
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.DrawImageUnscaledAndClipped(GetDrawLike(), new Rectangle(0x1, 0x1, 0x10, 0x10));
            graphics.DrawString(Text, Font, new SolidBrush(Enabled ? SnColor4 : SnColor5), 0x15, 0x3);
        }

        private static readonly Point[] point_0;
        private string Translator;
        private readonly Timer sTimer;
        private int Vert, Horiz, Dia;
        private Color SnColor;
        private readonly Color SnColor2, SnColor3, SnColor4, SnColor5;
    }
}