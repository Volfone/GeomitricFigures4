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
    class Rectangle : FilledFigure
    {
        public int Height;
        public int Width;
        public Pen pen;
        public SolidBrush brush;

        public Rectangle(Point point, int height, int width, SolidBrush brush, Pen pen) : base(point)
        {
            Height = height;
            Width = width;
            this.pen = pen;
            this.brush = brush;
        }

        public Rectangle(Point point, int height, int width, int brush, int pen, int penWidth) : base(point)
        {
            Height = height;
            Width = width;
            this.pen = new Pen(Color.FromArgb(pen), penWidth);
            this.brush = new SolidBrush(Color.FromArgb(brush));
        }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawRectangle(pen, base.basePoint.X, base.basePoint.Y, Width, Height);
            graphics.FillRectangle(brush, base.basePoint.X, base.basePoint.Y, Width,Height);
        }

        public override string ToString()
        {
            return $"Rectangle {base.basePoint.X} {base.basePoint.Y} {Height} {Width} {brush.Color.ToArgb()} {pen.Color.ToArgb()} {pen.Width}";
        }
    }
}
