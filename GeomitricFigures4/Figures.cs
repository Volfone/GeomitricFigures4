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
    class Figures : Figure
    {
        List<Figure> figures;
        public Figures()
        {
            figures = new List<Figure>();
        }

        public void Add(Figure figure)
        {
            figures.Add(figure);
        }

        public void Clear()
        {
            figures = new List<Figure>();
        }

        public void Save(string way)
        {
            using (StreamWriter sw = new StreamWriter(way, false, System.Text.Encoding.Default))
            { 
                foreach (Figure f in figures)
                {
                    sw.WriteLine($"{f.ToString()}");
                }
            }
        }

        public void Undo()
        {
            Figure Nf = null;
            foreach (Figure f in figures)
            {
                Nf = f;
            }
            figures.Remove(Nf);
        }

        public void Load(string way)
        {
            string s;
            string[] lines;

            using (StreamReader sr = new StreamReader(way, System.Text.Encoding.Default))
            {
                s = sr.ReadLine();
                while (s != null)
                {
                    lines = s.Split(' ');
                    int[] data = new int[lines.Length];
                    for (int i = 1; i < lines.Length; i++)
                    {
                        data[i] = int.Parse(lines[i]);
                    }
                    switch (lines[0])
                    {
                        case "Line":
                            figures.Add(new Line(new Point(data[1], data[2]), new Point(data[3], data[4]), data[5], data[6]));
                            break;
                        case "Triangle":
                            figures.Add(new Triangle(new Point(data[1], data[2]), new Point(data[3], data[4]), new Point(data[5], data[6]), data[7], data[8], data[9]));
                            break;
                        case "Circle":
                            figures.Add(new Circle(new Point(data[1], data[2]), data[3], data[4], data[5], data[6]));
                            break;
                        case "Rectangle":
                            figures.Add(new Rectangle(new Point(data[1], data[2]), data[3], data[4], data[5], data[6], data[7]));
                            break;
                    }
                    s = sr.ReadLine();
                }
            }
        }

        public void Draw(Graphics graphics)
        {
            foreach (var fig in figures)
            {
                fig.Draw(graphics);
            }
        }
    }
}
