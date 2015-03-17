using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicDesigner
{
    class Renderer
    {
        public Renderer()
        {
        }

        public void Render(IList<Point> points, InputOptions options)
        {
            SolidBrush brush = new SolidBrush(options.Color);

            foreach (Point p in points)
            {
                graphics.FillRectangle(brush, p.X, p.Y, (int)options.BrushSize, (int)options.BrushSize);

                //another way to draw points, which is slower
                //Bitmap bm = new Bitmap(1, 1);
                //bm.SetPixel(0, 0, Color.Red);
                //graphics.DrawImageUnscaled(bm, p.x, p.y);
            }
        }

        public void SetGraphics(ref Graphics graphics)
        {
            this.graphics = graphics;
        }

        private Graphics graphics;
    }
}
