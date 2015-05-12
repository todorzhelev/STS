using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GraphicDesigner.Utilities;

namespace GraphicDesigner
{
    class Renderer
    {
        private const int FormWidth = 900;
        private const int FormHeight = 700;

        public Renderer()
        {
            this.field = new Layer(0, 0, FormWidth, FormHeight, (int)LayerLevel.Field);
            //this.pastDrawing = this.field.Clone();
            this.currentDrawing = this.field.Clone();
        }

        public void Render(IList<Point> points, InputOptions options)
        {
            if (options.FigureType == FigureType.BezierCurve)
            {
                this.RemovePastLayer();
            }

            if (points.Count < 1)
            {
                return;
            }

            // copy past to field
            if (this.pastDrawing != null)
            {
                this.field.colorMatrix.SetMultiple(this.pastDrawing.colorMatrix);
            }

            // copy current to past
            this.pastDrawing = this.currentDrawing.Clone();
            this.pastDrawing.Level = (int)LayerLevel.Last;

            // create current
            this.currentDrawing = this.GetNewCurrentLayer(points);

            foreach (Point p in points)
            {
                int size = (int)options.BrushSize;

                for (int i = p.X; i < p.X + size; i++)
                {
                    for (int j = p.Y; j < p.Y + size; j++)
                    {
                        this.currentDrawing.colorMatrix.Set(i, j, options.Color);
                        this.DrawPoint(i, j, options.Color);
                    }
                } 
            }
        }

        public void RemovePastLayer()
        {
            if (this.pastDrawing == null)
            {
                return;
            }

            for (int i = this.pastDrawing.colorMatrix.StartX; i <= this.pastDrawing.colorMatrix.EndX; i++)
            {
                for (int j = this.pastDrawing.colorMatrix.StartY; j <= this.pastDrawing.colorMatrix.EndY; j++)
                {
                    if (this.field.colorMatrix.Get(i, j) != this.pastDrawing.colorMatrix.Get(i, j))
                    {
                        var color = this.field.colorMatrix.Get(i, j);
                        this.DrawPoint(i, j, color);
                    }
                }
            }

            this.pastDrawing = null;

        }

        public void SaveCurrentDrawingToField()
        {
            this.field = this.currentDrawing.Clone();
        }

        public void SetGraphics(ref Graphics graphics)
        {
            this.graphics = graphics;
        }


        private void DrawPoint(int x, int y, Color color)
        {
            var brush = new SolidBrush(color);
            graphics.FillRectangle(brush, x, y, 1, 1);

            //another way to draw points, which is slower
            //Bitmap bm = new Bitmap(1, 1);
            //bm.SetPixel(0, 0, Color.Red);
            //graphics.DrawImageUnscaled(bm, p.x, p.y);
        }

        private Layer GetNewCurrentLayer(IList<Point> points)
        {
            //var maxX = 0;
            //var minX = formWidth;
            //var maxY = 0;
            //var minY = formHeight;

            //foreach (Point p in points)
            //{
            //    if (p.X > maxX)
            //    {
            //        maxX = p.X;
            //    }

            //    if (p.X < minX)
            //    {
            //        minX = p.X;
            //    }

            //    if (p.Y > maxY)
            //    {
            //        maxY = p.Y;
            //    }

            //    if (p.Y < minY)
            //    {
            //        minY = p.Y;
            //    }
            //}

            //Layer currLayer = new Layer(minX, minY, maxX, maxY, (int)LayerLevel.Current);
            Layer currLayer = new Layer(0, 0, FormWidth, FormHeight, (int)LayerLevel.Current);
            return currLayer;
        }

        private Graphics graphics;

        public Layer field;
        public Layer currentDrawing;
        public Layer pastDrawing;
    }
}
