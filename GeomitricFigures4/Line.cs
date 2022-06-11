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
    class Line : Figure
    {
        string line;

        public Point A
        {
            get { return basePoint; }
            set { basePoint = value; }
        }
        public Point B;
        public Pen pen;

        public Line(Point A, Point B, Pen pen) : base(A)
        {
            this.B = B;
            this.pen = pen;
        }

        public Line(int x1, int y1, int x2, int y2, int pen, int penWidth) : base(x1, y1)
        {
            B = new Point(x2, y2);
            this.pen = new Pen(Color.FromArgb(pen), penWidth);
        }

        public Line(Point A, Point B, int pen, int penWidth) : base(A)
        {
            this.B = B;
            this.pen = new Pen(Color.FromArgb(pen), penWidth);
        }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawLine(pen, base.basePoint.X, base.basePoint.Y, B.X, B.Y);
        }

        public override string ToString()
        {
            return $"Line {base.basePoint.X} {base.basePoint.Y} {B.X} {B.Y} {pen.Color.ToArgb()} {pen.Width}";
        }
    }
}
