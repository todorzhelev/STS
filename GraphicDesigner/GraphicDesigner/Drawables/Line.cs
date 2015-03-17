using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicDesigner.Drawables
{
    class Line : IDrawable
    {
        public Line()
        {
            points = new List<Point>();
        }

        public IList<Point> GetPoints()
        {
            return points;
        }

        public void mouseDown(Point mouseCoords)
        {
            points = new List<Point>();

            sx = mouseCoords.X;
            sy = mouseCoords.Y;
        }

        public void mouseUp(Point mouseCoords)
        {
            Point p1 = new Point(sx, sy);
            Point p2 = new Point(mouseCoords.X, mouseCoords.Y);

            int x1 = p1.X;
            int x2 = p2.X;
            int y1 = p1.Y;
            int y2 = p2.Y;

            bool steep = (Math.Abs(y2 - y1) > Math.Abs(x2 - x1));
            if(steep)
            {
                Utilities.Misc.Swap(ref x1, ref y1);
                Utilities.Misc.Swap(ref x2, ref y2);
            }

            if(x1 > x2)
            {
                Utilities.Misc.Swap(ref x1, ref x2);
                Utilities.Misc.Swap(ref y1, ref y2);
            }

            float dx = x2 - x1;   
            float dy = Math.Abs(y2 - y1);

            float error = dx / 2.0f;
            int ystep = (y1 < y2) ? 1 : -1;
            int y = (int)y1;

            int maxX = (int)x2;

            for (int x = (int)x1; x < maxX; x++)
            {
                if (steep)
                {
                    points.Add(new Point(y, x));
                }
                else
                {
                    points.Add(new Point(x, y));
                }

                error -= dy;
                if (error < 0)
                {
                    y += ystep;
                    error += dx;
                }
            }
        }

        public FigureType FigureType
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        private IList<Point> points;
        private int sx, sy;
    }
}
