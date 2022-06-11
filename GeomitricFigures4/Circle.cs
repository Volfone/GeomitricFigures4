using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace GF3
{
    class Circle : FilledFigure
    {
        public int radius;
        public Pen pen;
        public SolidBrush brush;

        public Circle(Point point, int radius, SolidBrush brush, Pen pen) : base(point)
        {
            this.radius = radius;
            this.pen = pen;
            this.brush = brush;
        }
        public Circle(Point point, int radius, int brush, int pen, int width) : base(point)
        {
            this.radius = radius;
            this.pen = new Pen(Color.FromArgb(pen), width);
            this.brush = new SolidBrush(Color.FromArgb(brush));
        }

        public override void Draw(Graphics graphics)
        {
            graphics.FillEllipse(brush, base.basePoint.X, base.basePoint.Y, radius * 2, radius * 2);
            graphics.DrawEllipse(pen, base.basePoint.X, base.basePoint.Y, radius * 2, radius * 2);
        }

        public override string ToString()
        {
            return $"Circle {base.basePoint.X} {base.basePoint.Y} {radius} {brush.Color.ToArgb()} {pen.Color.ToArgb()} {pen.Width}";
        }
    }
}
