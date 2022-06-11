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
    class Triangle : FilledFigure
    {
        public Point A
        {
            get { return basePoint; }
            set { basePoint = value; }
        }
        public Point B;
        public Point C;
        public Pen pen;
        public SolidBrush brush;

        public Triangle(Point a, Point b, Point c, SolidBrush brush, Pen pen) : base(a)
        {
            B = b;
            C = c;
            this.pen = pen;
            this.brush = brush;
        }

        public Triangle(int x1, int y1, int x2, int y2, int x3, int y3, int brush, int pen, int width) : base(x1, y1)
        {
            B = new Point(x2, y2);
            C = new Point(x3, y3);
            this.pen = new Pen(Color.FromArgb(pen), width);
            this.brush = new SolidBrush(Color.FromArgb(brush));
        }

        public Triangle(Point a, Point b, Point c, int brush, int pen, int width) : base(a)
        {
            B = b;
            C = c;
            this.pen = new Pen(Color.FromArgb(pen), width);
            this.brush = new SolidBrush(Color.FromArgb(brush));
        }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawLine(pen, base.basePoint.X, base.basePoint.Y,  B.X, B.Y);
            graphics.DrawLine(pen, B.X, B.Y, C.X, C.Y);
            graphics.DrawLine(pen, base.basePoint.X, base.basePoint.Y, C.X, C.Y);

            System.Drawing.Point[] pts = { new System.Drawing.Point(base.basePoint.X, base.basePoint.Y), new System.Drawing.Point(B.X, B.Y), new System.Drawing.Point(C.X, C.Y) };
            graphics.FillPolygon(brush, pts);
        }

        public override string ToString()
        {
            return $"Triangle {base.basePoint.X} {base.basePoint.Y} {B.X} {B.Y} {C.X} {C.Y} {brush.Color.ToArgb()} {pen.Color.ToArgb()} {pen.Width}";
        }
    }
}
