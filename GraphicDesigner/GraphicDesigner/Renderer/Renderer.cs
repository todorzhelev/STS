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

        public Renderer(ref Graphics graphics)
        {
            this.graphics = graphics;
            this.ClearGraphics();

            this.connectPoints = true;
        }

        public void Render(IList<Point> points, InputOptions options)
        {

            if (points.Count < 1)
            {
                return;
            }

            Layer pastCopy = null;

            // copy past to field
            if (this.pastDrawing != null)
            {
                //this.pastDrawing.colorMatrix.SetMultiple(this.currentDrawing.colorMatrix);
                this.field.colorMatrix.SetMultiple(this.pastDrawing.colorMatrix);
                pastCopy = this.pastDrawing.Clone();
            }

            // copy current to past
            this.pastDrawing = this.currentDrawing.Clone();
            this.pastDrawing.Level = (int)LayerLevel.Last;


            if (options.CurrentFigure.NeedsRemovePastLayer)
            {
                this.RemoveLayer(ref this.currentDrawing);
            }


            // create current
            if (pastCopy != null)
            {
                this.currentDrawing = pastCopy;
            }
            else
            {
                this.currentDrawing = this.field.Clone();
            }
            this.currentDrawing.Level = (int)LayerLevel.Current;

            foreach (Point p in points)
            {
                int size = (int)options.BrushSize;

                for (int i = p.X; i < p.X + size; i++)
                {
                    for (int j = p.Y; j < p.Y + size; j++)
                    {
                        this.currentDrawing.colorMatrix.Set(i, j, options.Color);

                    }
                }
                this.DrawPoint(p.X, p.Y, options.Color, size);
            }

            if (this.connectPoints && options.CurrentFigure.NeedsConnectPoints)
            {
                for (int i = 0; i < points.Count - 1; i++)
                {
                    var line = new Drawables.Line();
                    line.GeneratePoints(points[i], points[i + 1]);
                    var linePoints = line.GetPoints();
                    foreach (var p in linePoints)
                    {
                        int size = (int)options.BrushSize;

                        for (int k = p.X; k < p.X + size; k++)
                        {
                            for (int j = p.Y; j < p.Y + size; j++)
                            {
                                this.currentDrawing.colorMatrix.Set(k, j, options.Color);

                            }
                        }
                        this.DrawPoint(p.X, p.Y, options.Color, size);
                    }
                }
            }
        }

        public void RemovePastLayer()
        {
            this.RemoveLayer(ref this.pastDrawing);
        }

        private void RemoveLayer(ref Layer layer)
        {
            if (layer == null)
            {
                return;
            }

            for (int i = layer.colorMatrix.StartX; i <= layer.colorMatrix.EndX; i++)
            {
                for (int j = layer.colorMatrix.StartY; j <= layer.colorMatrix.EndY; j++)
                {
                    if (this.field.colorMatrix.Get(i, j) != layer.colorMatrix.Get(i, j))
                    {
                        var color = this.field.colorMatrix.Get(i, j);
                        this.DrawPoint(i, j, color, 1);
                    }
                }
            }

            layer = null;
        }

        public void SaveCurrentDrawingToField()
        {
            if (this.pastDrawing != null)
            {
                this.pastDrawing.colorMatrix.SetMultiple(this.currentDrawing.colorMatrix);
                this.field.colorMatrix.SetMultiple(this.pastDrawing.colorMatrix);
                this.pastDrawing = null;
                this.currentDrawing.colorMatrix.SetMultiple(this.field.colorMatrix);
            }
            else
            {
                this.field.colorMatrix.SetMultiple(this.currentDrawing.colorMatrix);
            }

        }

        public void SetGraphics(ref Graphics graphics)
        {
            this.graphics = graphics;
        }

        private void DrawPoint(int x, int y, Color color, int size)
        {
            var brush = new SolidBrush(color);
            graphics.FillRectangle(brush, x, y, size, size);

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

        public void ClearGraphics()
        {
            graphics.Clear(Color.White);

            this.field = new Layer(0, 0, FormWidth, FormHeight, (int)LayerLevel.Field);
            this.pastDrawing = null;
            this.currentDrawing = new Layer(0, 0, FormWidth, FormHeight, (int)LayerLevel.Current);
        }

        private Graphics graphics;

        public Layer field;
        public Layer currentDrawing;
        public Layer pastDrawing;
        public bool connectPoints;
    }
}
