using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Diagnostics;

namespace GraphicDesigner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            graphics = this.CreateGraphics();
            //graphics.Clear(Color.White);
            this.MouseDown += mouseDown;
            this.MouseUp += mouseUp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stopwatch t = new Stopwatch();
            Graphics graphics = this.CreateGraphics();
           // Rectangle rectangle = new Rectangle(50, 50, 150, 150);
            //graphics.DrawEllipse(Pens.Black, rectangle);
            //graphics.DrawRectangle(Pens.Red, rectangle);

            //graphics.DrawLine(Pens.Black, 50, 50, 100,100);

            //Point pt = new Point(5, 8);

            //int x = Cursor.Position.X;
            //int y = Cursor.Position.Y;

            //Rectangle rectangle = new Rectangle(x - 100, y - 100, 1, 1);
            //graphics.DrawRectangle(Pens.Black, rectangle);
            
           // Point[] coords = new Point[300];
            var coords = new List<Point>();
            SolidBrush blueBrush = new SolidBrush(Color.Blue);

            double radius = 20;
          
                radius =  150;
                for (double i = 0; i < 360; i += 2)
                {
                    double angle = i * System.Math.PI / 180;
                    int x = (int)(150 + radius * System.Math.Cos(angle));
                    int y = (int)(150 + radius * System.Math.Sin(angle));
                    Point p = new Point(x, y);
                    coords.Add(p);
                }

                t.Start();
                foreach (Point p in coords)
                {
                    graphics.FillRectangle(blueBrush, p.X, p.Y, 2, 2);
                    //Bitmap bm = new Bitmap(1, 1);
                    //bm.SetPixel(0, 0, Color.Red);
                    //graphics.DrawImageUnscaled(bm, p.x, p.y);
                }
                t.Stop();
                TimeSpan ts =  t.Elapsed;
        }

        private void mouseDown(object sender, MouseEventArgs e)
        {
            this.x = e.X;
            this.y = e.Y;

           // graphics.DrawLine(Pens.Black, x, y, x+100, y+100);

            //Rectangle rectangle = new Rectangle(x, y, 1, 1);
            //graphics.DrawRectangle(Pens.Black, rectangle);
        }

        private void mouseUp(object sender, MouseEventArgs e)
        {
            //Bitmap bm = new Bitmap(1, 1);
            //bm.SetPixel(0, 0, Color.Red);
            //graphics.DrawImageUnscaled(bm, e.X, e.Y);

           graphics.DrawLine(Pens.Black, x, y, e.X, e.Y);

            //Rectangle rectangle = new Rectangle(x, y, 1, 1);
            //graphics.DrawRectangle(Pens.Black, rectangle);
           Point pt = new Point(3,4);
        }

        private Graphics graphics;
        private int x, y;

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
