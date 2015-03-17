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
        private const int DefaultBrushSize = 1;
        private static readonly Color DefaultColor = Color.Blue;
        private const FigureType DefaultFigureType = FigureType.Line;

        private Graphics graphics;
        private Renderer renderer;
        private InputOptions options;

        public STS()
        {
            InitializeComponent();
            graphics = this.CreateGraphics();
            this.MouseDown += mouseDown;
            this.MouseUp += mouseUp;
            renderer = new Renderer();
            renderer.SetGraphics(ref graphics);
            this.options = new InputOptions(DefaultColor, DefaultFigureType, DefaultBrushSize);
        }

        private void mouseDown(object sender, MouseEventArgs e)
        {
            this.options.CurrentFigure.mouseDown(new Point(e.X, e.Y));
        }

        private void mouseUp(object sender, MouseEventArgs e)
        {
            this.options.CurrentFigure.mouseUp(new Point(e.X, e.Y));

            IList<PointF> coords = this.options.CurrentFigure.GetPoints();

            renderer.Render(coords);
        }



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
            this.options.Color = colorDialog1.Color;
           
        }

        private void STS_Load(object sender, EventArgs e)
        {

        }

        private void Curve_Click(object sender, EventArgs e)
        {
            this.options.FigureType = FigureType.Curve;
        }

        private void Point_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Circle_Click(object sender, EventArgs e)
        {
            this.options.FigureType = FigureType.Ellipse;
        }

        private void Line_Click(object sender, EventArgs e)
        {
            this.options.FigureType = FigureType.Line;
        }
    }
}
