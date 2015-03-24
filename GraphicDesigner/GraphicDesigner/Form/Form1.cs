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
        private const Utilities.BrushSize DefaultBrushSize = Utilities.BrushSize.Small;
        private static readonly Color DefaultColor = Color.Blue;
        private const FigureType DefaultFigureType = FigureType.Pencil;

        private Graphics graphics;
        private Renderer renderer;
        private InputOptions options;

        public STS()
        {
            InitializeComponent();
            this.graphics = this.CreateGraphics();
            this.MouseDown += this.mouseDown;
            this.MouseUp += this.mouseUp;
            this.MouseMove += this.mouseMove;
            this.renderer = new Renderer();
            this.renderer.SetGraphics(ref graphics);
            this.options = new InputOptions(DefaultColor, DefaultFigureType, DefaultBrushSize);
        }

        private void mouseDown(object sender, MouseEventArgs e)
        {
            this.options.CurrentFigure.mouseDown(new Point(e.X, e.Y));
        }

        private void mouseUp(object sender, MouseEventArgs e)
        {
            this.options.CurrentFigure.mouseUp(new Point(e.X, e.Y));

            IList<Point> coords = this.options.CurrentFigure.GetPoints();

            renderer.Render(coords, this.options);
        }

        private void mouseMove(object sender, MouseEventArgs e)
        {
            this.options.CurrentFigure.mouseMove(new Point(e.X, e.Y));
        }



        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        } 
        
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OD = new OpenFileDialog();
            OD.ShowDialog();     
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

        private void Circle_Click(object sender, EventArgs e)
        {
            this.options.FigureType = FigureType.Ellipse;
        }

        private void Point_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }      

        private void Line_Click(object sender, EventArgs e)
        {
            this.options.FigureType = FigureType.Line;
        }

        private void Rectangle_Click(object sender, EventArgs e)
        {
            this.options.FigureType = FigureType.Rectangle;
        }
        
        ContextMenuStrip contextMenuStrip1 = new ContextMenuStrip();
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void bezier_Click(object sender, EventArgs e)
        {
            this.options.FigureType = FigureType.BezierCurve;
        }

        private void spline_Click(object sender, EventArgs e)
        {
            this.options.FigureType = FigureType.SplineCurve;
        }

        private void line1ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.options.BrushSize = Utilities.BrushSize.Small;
        }

        private void line2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.options.BrushSize = Utilities.BrushSize.Medium;
        }

        private void line3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.options.BrushSize = Utilities.BrushSize.Large;
        }
       
    }
}
