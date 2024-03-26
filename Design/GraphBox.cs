namespace DaddyRecoveryBuilder.Design
{
    using System.Drawing;
    using System.Drawing.Drawing2D;

    public static class GraphBox
    {
        private const double V = 255.0, S = 1.0;

        public static GraphicsPath Graph1(float one, float two, float three, float fo, float five)
        {
            var graphicsPath = new GraphicsPath();
            graphicsPath.AddLine(one + five, two, one + three - (five * 0x2), two);
            graphicsPath.AddArc(one + three - (five * 0x2), two, five * 0x2, five * 0x2, 0x10E, 0x5A);
            graphicsPath.AddLine(one + three, two + five, one + three, two + fo - (five * 0x2));
            graphicsPath.AddArc(one + three - (five * 0x2), two + fo - (five * 0x2), five * 0x2, five * 0x2, 0x0, 90);
            graphicsPath.AddLine(one + three - (five * 0x2), two + fo, one + five, two + fo);
            graphicsPath.AddArc(one, two + fo - (five * 0x2), five * 0x2, five * 0x2, 0x5A, 0x5A);
            graphicsPath.AddLine(one, two + fo - (five * 0x2), one, two + five);
            graphicsPath.AddArc(one, two, five * 0x2, five * 0x2, 180, 90);
            graphicsPath.CloseFigure();
            return graphicsPath;
        }
        public static GraphicsPath Graph2(float one, float two, float three, float fo, float five)
        {
            var graphicsPath = new GraphicsPath();
            graphicsPath.AddLine(one + five, two, one + three - (five * 0x2), two);
            graphicsPath.AddArc(one + three - (five * 0x22), two, five * 0x2, five * 0x2, 0x10E, 0x5A);
            graphicsPath.AddLine(one + three, two + five, one + three, two + fo - (five * 0x2) + 0x1);
            graphicsPath.AddArc(one + three - (five * 0x2), two + fo - (five * 0x2), five * 0x2, 0x2, 0x0, 0x5A);
            graphicsPath.AddLine(one + three, two + fo, one + five, two + fo);
            graphicsPath.AddArc(one, two + fo - (five * 0x2) + 0x1, five * 0x2, 0x1, 0x5A, 0x5A);
            graphicsPath.AddLine(one, two + fo, one, two + five);
            graphicsPath.AddArc(one, two, five * 0x2, five * 0x2, 0xB4, 0x5A);
            graphicsPath.CloseFigure();
            return graphicsPath;
        }
        public static GraphicsPath Graph3(float one, float two, float three, float fo, float five)
        {
            var graphicsPath = new GraphicsPath();
            graphicsPath.AddLine(one + five, two, one + three - (five * 0x2), two);
            graphicsPath.AddArc(one + three - (five * 0x2), two, five * 0x2, five * 0x2, 0x10E, 0x5A);
            graphicsPath.AddLine(one + three, two + 0x0, one + three, two + fo);
            graphicsPath.AddArc(one + three - (five * 0x2), two + fo - 1, five * 0x2, 0x1, 0x0, 0x5A);
            graphicsPath.AddLine(one + three - (five * 0x2), two + fo, one + five, two + fo);
            graphicsPath.AddArc(one, two + fo - (five * 0x2), five * 0x2, five * 0x2, 0x5A, 0x5A);
            graphicsPath.AddLine(one, two + fo - (five * 0x2), one, two + five);
            graphicsPath.AddArc(one, two, five * 0x2, five * 0x2, 0xB4, 0x5A);
            graphicsPath.CloseFigure();
            return graphicsPath;
        }

        public static Color NColor(Color one, Color two, double db) => Color.FromArgb((int)((one.R * (S - (db / V))) + (two.R * (db / V))), (int)((one.G * (S - (db / V))) + (two.G * (db / V))), (int)((one.B * (S - (db / V))) + (two.B * (db / V))));
        public static Color GpColor(Color one, Color two) => Color.FromArgb((int)((one.R * (double)1) + (two.R * 0.0)), (int)((one.G * (double)1) + (two.G * 0.0)), (int)((one.B * (double)1) + (two.B * 0.0)));
        public static GraphicsPath Graph4(Rectangle rectangle_0, float float_0) => Graph1(rectangle_0.X, rectangle_0.Y, rectangle_0.Width, rectangle_0.Height, float_0);
    }
}