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
    public partial class STS : Form
    {
        public STS()
        {
            InitializeComponent();
            graphics = this.CreateGraphics();
            this.MouseDown += mouseDown;
            this.MouseUp += mouseUp;
            renderer = new Renderer();
            renderer.SetGraphics(ref graphics);
            currentFigure = new Drawables.Line();
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

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OD = new OpenFileDialog();
            OD.ShowDialog();
            //your code goes here
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog SD = new SaveFileDialog();
            SD.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ColorButton_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            ColorButton.BackColor = colorDialog1.Color;
           // this.commandBarButton1.Image = Image.FromFile("b5aeff9e250.jpg").GetThumbnailImage(100, 100, null, IntPtr.Zero);
        }

        private void STS_Load(object sender, EventArgs e)
        {

        }

        private void Curve_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            Curve.BackColor = colorDialog1.Color;
        }

        private void Point_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            Point.BackColor = colorDialog1.Color;
        }

        private void Circle_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            Circle.BackColor = colorDialog1.Color;
        }

        private void Line_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            Line.BackColor = colorDialog1.Color;
        }

      
       
    }
}
