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

            //Point p1 = new Point(1, 1);
            //Point p2 = new Point(4, 3);

            int x1 = p1.X;
            int x2 = p2.X;
            int y1 = p1.Y;
            int y2 = p2.Y;

            int deltaX = x2 - x1;
            int deltaY = y2 - y1;
            float slope = (float)deltaY / deltaX;

            int yIncr = slope >= 0 ? 1 : -1;

            float offset = 0;
            float threshold = 0.5f;

            if( slope >= -1 && slope <= 1)
            {
                float delta = Math.Abs(slope);
                int y = y1;
                if( x2 < x1 )
                {
                    Utilities.Misc.Swap(ref x1, ref x2);
                    y = y2;
                }

                for( int x = x1; x <= x2; x++)
                {
                    if (offset >= threshold)
                    {
                        y += yIncr;
                        threshold += 1;
                    }

                    points.Add(new Point(x, y));
                    offset += delta;
                }
            }
            else
            {
                float delta = Math.Abs((float)deltaX / deltaY);
                int x = x1;
                if( y2 < y1 ) 
                {
                    Utilities.Misc.Swap(ref y1, ref y2);
                    x = x2;
                }

                for( int y = y1; y <= y2; y++)
                {
                    if (offset >= threshold)
                    {
                        x += yIncr;
                        threshold += 1;
                    }

                    points.Add(new Point(x, y));
                    offset += delta;
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
