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
        private const ToolType DefaultToolType = ToolType.Unknown;

        private  InputOptions prevOptions;
        private bool IsEraserUsed;

        private Graphics graphics;
        private Renderer renderer;
        private InputOptions options;

        private IList<Point> selectedPoints;
        private Point selectedPointsCenter;

        public STS()
        {
            InitializeComponent();
            this.graphics = this.CreateGraphics();
            this.MouseDown += this.mouseDown;
            this.MouseUp += this.mouseUp;
            this.MouseMove += this.mouseMove;
            this.renderer = new Renderer(ref graphics);
            this.renderer.SetGraphics(ref graphics);
            this.options = new InputOptions(DefaultColor, DefaultFigureType, DefaultBrushSize, DefaultToolType);
            this.Cursor = Cursors.Default;
            this.prevOptions = new InputOptions(DefaultColor, DefaultFigureType, DefaultBrushSize, DefaultToolType);
            this.IsEraserUsed = false;
            selectedPoints = new List<Point>();
        }

        private void ApplyPreviousOptions()
        {
            if (this.IsEraserUsed )
            {
                this.options.Color = this.prevOptions.Color;
                this.options.BrushSize = this.prevOptions.BrushSize;
            }

            this.IsEraserUsed = false;
            this.options.CurrentTool.ToolType = ToolType.Unknown;

            this.renderer.SaveCurrentDrawingToField();
        }

        private void mouseDown(object sender, MouseEventArgs e)
        {
            if (this.options.CurrentTool.ToolType == ToolType.Unknown)
            {
                this.options.CurrentFigure.mouseDown(new Point(e.X, e.Y));
            }
            else
            {
                this.options.CurrentTool.mouseDown(new Point(e.X, e.Y));
            }
        }

        private void mouseUp(object sender, MouseEventArgs e)
        {
            if (this.options.CurrentTool.ToolType == ToolType.Unknown )
            {
                this.options.CurrentFigure.mouseUp(new Point(e.X, e.Y));

                IList<Point> coords = this.options.CurrentFigure.GetPoints();

                if (this.options.CurrentFigure.NeedsRemovePastLayer)
                {
                    renderer.RemovePastLayer();
                }

                renderer.Render(coords, this.options);
            }
            else if( this.options.CurrentTool.ToolType == ToolType.Select)
            {
                this.options.CurrentTool.mouseUp(new Point(e.X, e.Y),ref renderer);
                selectedPoints = this.options.CurrentTool.GetPoints();
                selectedPointsCenter = this.options.CurrentTool.GetCenter();
                //this.options.Color = Color.White;
               // renderer.Render(coords, this.options);
            }
            //else if( this.options.CurrentTool.ToolType == ToolType.Rotate)
            //{
            //    this.options.CurrentTool.mouseUp(new Point(e.X, e.Y),ref renderer);

            //    Tools.Rotate r = (Tools.Rotate)(this.options.CurrentTool);

            //    IList<Point> coords = r.GetPoints(ref selectedPoints);

            //    renderer.Render(coords, this.options);
            //}
           
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
            this.renderer.ClearGraphics();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OD = new OpenFileDialog();
            OD.Title = "Open Photo";
            OD.Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*" ;

            if (OD.ShowDialog() == DialogResult.OK)
            {
                ///pictureBox1.Image = new Bitmap(OD.OpenFile());
            }
                OD.Dispose();

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
            ApplyPreviousOptions();
            this.options.FigureType = FigureType.Circle;
        }

        private void Point_Click(object sender, EventArgs e)
        {
            ApplyPreviousOptions();
            this.options.FigureType = FigureType.Pencil;
        }      

        private void Line_Click(object sender, EventArgs e)
        {
            ApplyPreviousOptions();
            this.options.FigureType = FigureType.Line;
        }

        private void Rectangle_Click(object sender, EventArgs e)
        {
            ApplyPreviousOptions();
            this.options.FigureType = FigureType.Rectangle;
        }
        
        ContextMenuStrip contextMenuStrip1 = new ContextMenuStrip();
        private void button1_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(Control.MousePosition);
        }

        private void bezier_Click(object sender, EventArgs e)
        {
            ApplyPreviousOptions();
            this.options.FigureType = FigureType.BezierCurve;
        }

        private void spline_Click(object sender, EventArgs e)
        {
            ApplyPreviousOptions();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void eraser_Click(object sender, EventArgs e)
        {
            IsEraserUsed = true;
            this.options.FigureType = FigureType.Eraser;
            this.prevOptions.Color = this.options.Color;
            this.prevOptions.BrushSize = this.options.BrushSize;
            this.prevOptions.FigureType = this.options.FigureType;
            this.options.Color = Color.White;
            this.options.BrushSize = Utilities.BrushSize.Large;
        }

        private void Triangle_Click(object sender, EventArgs e)
        {
            ApplyPreviousOptions();
            this.options.FigureType = FigureType.Triangle;
        }

        private void Square_Click(object sender, EventArgs e)
        {
            ApplyPreviousOptions();
            this.options.FigureType = FigureType.Square;
        }

        private void Ellipse_Click(object sender, EventArgs e)
        {
            ApplyPreviousOptions();
            this.options.FigureType = FigureType.Ellipse;
        }

        private void select_Click(object sender, EventArgs e)
        {
            this.options.CurrentTool.ToolType = ToolType.Select;
        }


        private void Rotate_Click(object sender, EventArgs e)
        {
            this.options.CurrentTool.ToolType = ToolType.Rotate;
           // this.options.CurrentTool.mouseUp(new Point(e.X, e.Y), ref renderer);

            //Tools.Rotate r = (Tools.Rotate)(this.options.CurrentTool);
            Tools.Rotate r = new Tools.Rotate(ref renderer);

            IList<Point> coords = r.GetPoints(ref selectedPoints, selectedPointsCenter.X, selectedPointsCenter.Y);
            renderer.connectPoints = false;
            renderer.Render(coords, this.options);
            renderer.connectPoints = true;
        }
       
    }
}
