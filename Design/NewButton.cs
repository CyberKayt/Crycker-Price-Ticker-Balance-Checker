namespace DaddyRecoveryBuilder.Design
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    public class NewButton : Control
    {
        private readonly Timer timer_0;
        private readonly StringFormat stringFormat_0;
        private Rectangle vwghvFuJlp;
        private bool bool_0;
        private int int_0, int_1;
        private float float_0, float_1;
        private string string_0, string_1;
        private Color color_0, color_1;
        private readonly Color color_2, color_3;

        [Category("Appearance")]
        public string BGColor
        {
            get => string_1;
            set
            {
                string_1 = value;
                Invalidate();
            }
        }
        [Category("Appearance")]
        public string FontColor
        {
            get => string_0;
            set
            {
                string_0 = value;
                Invalidate();
            }
        }
        [Browsable(true)]
        public new Font Font
        {
            get => base.Font;
            set => base.Font = value;
        }
        [Browsable(false)]
        public new Color ForeColor
        {
            get => base.ForeColor;
            set => base.ForeColor = value;
        }
        protected void AnimationTick(object sender, EventArgs e)
        {
            if (bool_0)
            {
                if (float_0 < Width + 550)
                {
                    float_0 += float_1;
                    Invalidate();
                    return;
                }
            }
            else if (float_0 > 0f)
            {
                float_0 = 0f;
                Invalidate();
            }
        }
        public NewButton()
        {
            timer_0 = new Timer { Interval = 1 };
            stringFormat_0 = new StringFormat();
            string_0 = "#ffffff";
            string_1 = "#20262C";
            color_2 = ColorTranslator.FromHtml("#b0b2b5");
            color_3 = ColorTranslator.FromHtml("#18181B");
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            Size = new Size(143, 41);
            BackColor = Color.Transparent;
            stringFormat_0.Alignment = StringAlignment.Center;
            stringFormat_0.LineAlignment = StringAlignment.Center;
            timer_0.Tick += AnimationTick;
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            vwghvFuJlp = new Rectangle(0, 0, Width, Height);
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            float_1 = Width / 34;
        }
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            bool_0 = false;
            timer_0.Start();
            Invalidate();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            int_0 = e.X;
            int_1 = e.Y;
            bool_0 = true;
            timer_0.Start();
            Invalidate();
        }

        // Default
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.Clear(Parent.BackColor);
            color_1 = ColorTranslator.FromHtml(string_0);
            color_0 = ColorTranslator.FromHtml(string_1);
            using (GraphicsPath path = GraphBox.Graph1(1f, 1f, Width - 3, Height - 3, 1f))
            {
                graphics.FillPath(new SolidBrush(Enabled ? color_0 : color_2), path);
                graphics.DrawPath(new Pen(Enabled ? color_0 : color_2), path);
                using Region region = new Region(path);
                graphics.SetClip(region, CombineMode.Replace);
            }
            graphics.FillEllipse(new SolidBrush(Color.FromArgb(24, Color.Black)), int_0 - float_0 / 2f, int_1 - float_0 / 2f, float_0, float_0);
            graphics.DrawString(Text, Font, new SolidBrush(color_1), vwghvFuJlp, stringFormat_0);
        }
        
        
        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    base.OnPaint(e);
        //    Graphics graphics = e.Graphics;
        //    graphics.SmoothingMode = SmoothingMode.HighQuality;
        //    graphics.Clear(Parent.BackColor);
        //    color_1 = ColorTranslator.FromHtml(string_0);
        //    color_0 = ColorTranslator.FromHtml(string_1);
        //    using (GraphicsPath path = GraphBox.Graph1(1f, 1f, Width - 3, Height - 3, 1f))
        //    {
        //        graphics.FillPath(new SolidBrush(color_3), path); // Задний фон кнопки (цвет)
        //        graphics.DrawPath(new Pen(Enabled ? color_0 : color_2), path);
        //        using Region region = new Region(path);
        //        graphics.SetClip(region, CombineMode.Replace);
        //    }
        //    // Клик процвет
        //    graphics.FillEllipse(new SolidBrush(Color.FromArgb(50, ColorTranslator.FromHtml("#9D68EE"))), int_0 - float_0 / 2f, int_1 - float_0 / 2f, float_0, float_0);
        //    graphics.DrawString(Text, Font, new SolidBrush(color_1), vwghvFuJlp, stringFormat_0); // Цвет текста
        //}
    }
}