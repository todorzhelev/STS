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
        public Layer field;
        public Layer currentDrawing;
        public Layer pastDrawing;
        private Graphics graphics;

        public Renderer(ref Graphics graphics)
        {
            this.graphics = graphics;
            this.ClearGraphics();
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
                this.field.SetMultiple(this.pastDrawing);
                pastCopy = this.pastDrawing.Clone();
            }

            // copy current to past
            this.pastDrawing = this.currentDrawing.Clone();
            this.pastDrawing.Level = LayerLevel.Last;


            if (options.CurrentFigure.NeedsRemovePastLayer && options.CurrentTool.ToolType == ToolType.Unknown)
            {
                this.RemoveLayer(ref this.currentDrawing);
            }

            // copy current to field (current is already past)
            if (this.currentDrawing != null)
            {
                this.field.SetMultiple(this.currentDrawing);
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
            this.currentDrawing.Level = LayerLevel.Current;

            foreach (Point p in points)
            {
                int size = (int)options.BrushSize;

                for (int i = p.X; i < p.X + size; i++)
                {
                    for (int j = p.Y; j < p.Y + size; j++)
                    {
                        this.currentDrawing.Set(i, j, options.Color);

                    }
                }
                this.DrawPoint(p.X, p.Y, options.Color, size);
            }

            if (options.CurrentFigure.NeedsConnectPoints && options.CurrentTool.ToolType == ToolType.Unknown)
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
                                this.currentDrawing.Set(k, j, options.Color);
                            }
                        }

                        this.DrawPoint(p.X, p.Y, options.Color, size);
                    }
                }
            }
        }

        public void RenderLayer(Layer layer)
        {
            this.SaveCurrentDrawingToField();
            for (int i = layer.StartX; i < layer.EndX; i++)
            {
                for (int j = layer.StartY; j < layer.EndY; j++)
                {
                    var color = layer.Get(i, j);
                    if (color == Color.White)
                    {
                        continue;
                    }
                    this.DrawPoint(i, j, color, 1);
                    this.currentDrawing.Set(i, j, color);
                }
            }
        }

        public void ClearGraphics()
        {
            graphics.Clear(Color.White);

            this.field = new Layer(0, 0, Constants.FormWidth, Constants.FormHeight, LayerLevel.Field);
            this.pastDrawing = null;
            this.currentDrawing = new Layer(0, 0, Constants.FormWidth, Constants.FormHeight, LayerLevel.Current);
        }

        public void SaveCurrentDrawingToField()
        {
            if (this.pastDrawing != null)
            {
                this.pastDrawing.SetMultiple(this.currentDrawing);
                this.field.SetMultiple(this.pastDrawing);
                this.pastDrawing = null;
                this.currentDrawing.SetMultiple(this.field);
            }
            else
            {
                this.field.SetMultiple(this.currentDrawing);
            }

        }

        public void RemovePastLayer()
        {
            this.RemoveLayer(ref this.pastDrawing);
        }

        public void DrawImage(Bitmap image)
        {
            int iStart = Constants.DrawStart.X;
            int iEnd = Math.Min(image.Width, Constants.DrawEnd.X);
            int jStart = Constants.DrawStart.Y;
            int jEnd = Math.Min(image.Height, Constants.DrawEnd.Y);

            for (int i = iStart; i < iEnd; i++)
            {
                for (int j = jStart; j < jEnd; j++)
                {
                    this.DrawPoint(i, j, image.GetPixel(i - iStart, j - jStart), 1);
                    this.currentDrawing.Set(i, j, image.GetPixel(i - iStart, j - jStart));
                }
            }
        }

        public void DrawPoint(int x, int y, Color color, int size)
        {
            if (x >= Constants.DrawStart.X && x <= Constants.DrawEnd.X
                && y >= Constants.DrawStart.Y && y <= Constants.DrawEnd.Y)
            {
                var brush = new SolidBrush(color);
                graphics.FillRectangle(brush, x, y, size, size);
            }

            //another way to draw points, which is slower
            //Bitmap bm = new Bitmap(1, 1);
            //bm.SetPixel(0, 0, Color.Red);
            //graphics.DrawImageUnscaled(bm, p.x, p.y);
        }

        private void RemoveLayer(ref Layer layer)
        {
            if (layer == null)
            {
                return;
            }

            for (int i = layer.StartX; i <= layer.EndX; i++)
            {
                for (int j = layer.StartY; j <= layer.EndY; j++)
                {
                    if (this.field.Get(i, j) != layer.Get(i, j))
                    {
                        var color = this.field.Get(i, j);
                        this.DrawPoint(i, j, color, 1);
                    }
                }
            }

            layer = null;
        }

        private Layer GetNewCurrentLayer(IList<Point> points)
        {
            var maxX = 0;
            var minX = Constants.FormWidth;
            var maxY = 0;
            var minY = Constants.FormHeight;

            foreach (Point p in points)
            {
                if (p.X > maxX)
                {
                    maxX = p.X;
                }

                if (p.X < minX)
                {
                    minX = p.X;
                }

                if (p.Y > maxY)
                {
                    maxY = p.Y;
                }

                if (p.Y < minY)
                {
                    minY = p.Y;
                }
            }

            Layer currLayer = new Layer(minX, minY, maxX, maxY, LayerLevel.Current);
            //Layer currLayer = new Layer(0, 0, FormWidth, FormHeight, (int)LayerLevel.Current);
            return currLayer;
        }
    }
}
