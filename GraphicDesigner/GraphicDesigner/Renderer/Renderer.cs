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
        private const int formWidth = 900;
        private const int formHeight = 700;

        public Renderer()
        {
            this.field = new Layer(0, 0, formWidth, formHeight, (int)LayerLevel.Field);
        }

        public void Render(IList<Point> points, InputOptions options)
        {
            if (points.Count < 1)
            {
                return;
            }

            if (this.pastDrawing != null)
            {
                this.field.colorMatrix.SetMultiple(this.pastDrawing.colorMatrix);
            }

            this.pastDrawing = this.currentDrawing;

            this.currentDrawing = GetNewCurrentLayer(points);

            SolidBrush brush = new SolidBrush(options.Color);
            foreach (Point p in points)
            {
                graphics.FillRectangle(brush, p.X, p.Y, (int)options.BrushSize, (int)options.BrushSize);
                if (points.Count > 1)
                {
                    // TODO brushsize cycle
                    this.currentDrawing.colorMatrix.Set(p.X, p.Y, options.Color);
                }
                
                //another way to draw points, which is slower
                //Bitmap bm = new Bitmap(1, 1);
                //bm.SetPixel(0, 0, Color.Red);
                //graphics.DrawImageUnscaled(bm, p.x, p.y);
            }
        }

        private static Layer GetNewCurrentLayer(IList<Point> points)
        {
            var maxX = 0;
            var minX = formWidth;
            var maxY = 0;
            var minY = formHeight;

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

            Layer currLayer = new Layer(minX, minY, maxX, maxY, (int)LayerLevel.Current);
            return currLayer;
        }

        public void RemovePastLayer()
        {
            // TODO
            this.pastDrawing = null;
        }

        public void SetGraphics(ref Graphics graphics)
        {
            this.graphics = graphics;
        }

        private Graphics graphics;

        public Layer field;
        public Layer currentDrawing;
        public Layer pastDrawing;
    }
}
