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
    class Figure
    {
        protected Point basePoint;

        public Figure()
        {

        }

        public Figure(Point point)
        {
            basePoint = point;
        }

        public Figure(int x, int y)
        {
            basePoint = new Point(x, y);
        }

        public virtual void Draw(Graphics graphics)
        {
            
        }

        public virtual string ToString()
        { 
            return $"{basePoint.X}, {basePoint.Y}"; 
        }
    }
}
