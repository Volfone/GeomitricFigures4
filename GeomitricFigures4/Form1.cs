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
    public partial class FigureForm : Form
    {
        Graphics graphics;
        Figures image = new Figures();
        string selectedFigure = "";
        Color brushColor = Color.White;
        Color penColor = Color.Black;
        public int x1, y1, x2, y2, x3, y3, sx, sy, bx, by, Mouse_click = 0;

        public FigureForm()
        {
            InitializeComponent();
        }

        private void ChoiceColor(Button textBox)
        {
            if (colorDialogFigure.ShowDialog() == DialogResult.Cancel)
                return;
            textBox.BackColor = colorDialogFigure.Color;
        }

        public void Figure_Load(object sender, EventArgs e)
        {
            graphics = Canvas.CreateGraphics();
        }

        private void FigureB_Click(object sender, EventArgs e)
        {
            selectedFigure = (sender as Button).Text;
            Mouse_click = 0;
            Canvas.Refresh();
            image.Draw(graphics);
        }

        private void CustomBrushColorChange(object sender, EventArgs e)
        {
            ChoiceColor(CustomC);
            brushColor = (sender as Button).BackColor;
        }
        private void BrushColorChange(object sender, EventArgs e)
        {
            brushColor = (sender as Button).BackColor;
        }

        private void CustomPenColorChange(object sender, EventArgs e)
        {
            ChoiceColor(CustomP);
            penColor = (sender as Button).BackColor;
        }

        private void PenColorChange(object sender, EventArgs e)
        {
            penColor = (sender as Button).BackColor;
        }

        private void Canvas_Resize(object sender, EventArgs e)
        {
            image.Draw(graphics);
        }

        private void Canvas_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (selectedFigure == cirB.Text)
            {
                if (Mouse_click % 2 == 0)
                {
                    x1 = e.X;
                    y1 = e.Y;
                    drawDot(x1, y1);
                }
                else if (Mouse_click % 2 == 1)
                {
                    x2 = e.X;
                    y2 = e.Y;
                    sx = Math.Min(x1, x2);
                    sy = Math.Min(y1, y2);
                    bx = Math.Max(x1, x2);
                    by = Math.Max(y1, y2);
                    double katet1 = Math.Pow(bx - sx, 2);
                    double katet2 = Math.Pow(by - sy, 2);
                    int radius = (int)Math.Sqrt(katet1 + katet2);
                    image.Add(new Circle(new Point(x1 - radius, y1 - radius), radius, new SolidBrush(brushColor), new Pen(penColor, ScrollB.Value)));
                    Canvas.Refresh();
                    image.Draw(graphics);
                }
            }
            else if (selectedFigure == linB.Text)
            {
                if (Mouse_click % 2 == 0)
                {
                    x1 = e.X;
                    y1 = e.Y;
                    drawDot(x1, y1);
                }
                else if (Mouse_click % 2 == 1)
                {
                    x2 = e.X;
                    y2 = e.Y;

                    image.Add(new Line(new Point(x1, y1), new Point(x2, y2), new Pen(penColor, ScrollB.Value)));
                    Canvas.Refresh();
                    image.Draw(graphics);
                }
            }
            else if (selectedFigure == recB.Text)
            {
                if (Mouse_click % 2 == 0)
                {
                    x1 = e.X;
                    y1 = e.Y;
                    drawDot(x1, y1);
                }
                else if (Mouse_click % 2 == 1)
                {
                    x2 = e.X;
                    y2 = e.Y;
                    sx = Math.Min(x1, x2);
                    sy = Math.Min(y1, y2);
                    bx = Math.Max(x1, x2);
                    by = Math.Max(y1, y2);
                    int width = bx - sx;
                    int height = by - sy;

                    image.Add(new GF3.Rectangle(new Point(sx, sy), height, width, new SolidBrush(brushColor), new Pen(penColor, ScrollB.Value)));
                    Canvas.Refresh();
                    image.Draw(graphics);
                }
            }
            else if (selectedFigure == triB.Text)
            {
                if (Mouse_click % 3 == 0)
                {
                    x1 = e.X;
                    y1 = e.Y;
                    drawDot(x1, y1);
                }
                else if (Mouse_click % 3 == 1)
                {
                    x2 = e.X;
                    y2 = e.Y;
                    drawDot(x2, y2);
                }
                else if (Mouse_click % 3 == 2)
                {
                    x3 = e.X;
                    y3 = e.Y;

                    image.Add(new GF3.Triangle(new Point(x1, y1), new Point(x2, y2), new Point(x3, y3), new SolidBrush(brushColor), new Pen(penColor, ScrollB.Value)));
                    Canvas.Refresh();
                    image.Draw(graphics);
                }
            }
            Mouse_click++;
        }

        private void Canvas_ClientSizeChanged_1(object sender, EventArgs e)
        {
            graphics.Dispose();
            graphics = Canvas.CreateGraphics();
            image.Draw(graphics);
        }

        private void Canvas_VisibleChanged(object sender, EventArgs e)
        {
            image.Draw(graphics);
        }

        private void NeededB_Click(object sender, EventArgs e)
        {
            image.Undo();
            graphics.Clear(Color.White);
            image.Draw(graphics);
        }

        private void BlueP_Click(object sender, EventArgs e)
        {
            penColor = BlueP.BackColor;
        }

        private void ClearB_Click(object sender, EventArgs e)
        {
            graphics.Clear(Color.White);
            image.Clear();
        }

        private void panelLine_Paint(object sender, PaintEventArgs e)
        {
            image.Draw(graphics);
        }

        private void ItemSave_Click(object sender, EventArgs e)
        {
            if(dlgSave.ShowDialog() == DialogResult.OK)
            {
                string fname = dlgSave.FileName;
                image.Save(fname);
            }
        }

        private void itemLoad_Click(object sender, EventArgs e)
        {
            if (dlgLoad.ShowDialog() == DialogResult.OK)
            {
                string fname = dlgLoad.FileName;
                image.Clear();
                image.Load(fname);
                Canvas.Refresh();
            }
            image.Draw(graphics);
        }

        private void itemNewFile_Click(object sender, EventArgs e)
        {
            if (dlgSave.ShowDialog() == DialogResult.OK)
            {
                string fname = dlgSave.FileName;
                image.Clear();
                image.Save(fname);
                Canvas.Refresh();
            }
            image.Draw(graphics);
        }

        private void drawDot(int x1, int y1)
        {
            graphics.DrawEllipse(new Pen(Color.Red, 2), x1, y1, 1, 1);
        }
    }
}