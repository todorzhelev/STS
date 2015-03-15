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
            this.MouseDown += mouseDown;
            this.MouseUp += mouseUp;
            renderer = new Renderer();
            renderer.SetGraphics(ref graphics);
            currentFigure = new Drawables.Ellipse();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mouseDown(object sender, MouseEventArgs e)
        {
            currentFigure.mouseDown(new Point(e.X, e.Y));
        }

        private void mouseUp(object sender, MouseEventArgs e)
        {
            currentFigure.mouseUp(new Point(e.X, e.Y));

            IList<PointF> coords = currentFigure.GetPoints();

            renderer.Render(coords);
        }

        private Graphics graphics;
        private Renderer renderer;

        IDrawable currentFigure;
    }
}
