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
    class FilledFigure : Figure
    {
        public SolidBrush Fill;
        public Pen Stroke;

        public FilledFigure(Point point, SolidBrush fill, Pen stroke) : base(point)
        {
            Fill = fill;
            Stroke = stroke;
        }

        public FilledFigure(int x, int y, SolidBrush fill, Pen stroke) : base(x, y)
        {
            Fill = fill;
            Stroke = stroke;
        }

        public FilledFigure(int x, int y) : base(x, y)
        {
            basePoint = new Point(x, y);
        }

        public FilledFigure(Point point) : base(point)
        {
            basePoint = point;
        }
    }

    struct Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"[{X}, {Y}]";
        }
    }
}
