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

            start = mouseCoords;
        }

        public void mouseUp(Point mouseCoords)
        {
            Point end = new Point(mouseCoords.X, mouseCoords.Y);
            GeneratePoints(start, end);
        }

        public void GeneratePoints(Point p1, Point p2)
        {
            int x1 = p1.X;
            int x2 = p2.X;
            int y1 = p1.Y;
            int y2 = p2.Y;

            //finds the slope of the line
            int deltaX = x2 - x1;
            int deltaY = y2 - y1;
            float slope = (float)deltaY / deltaX;

            //if the slope is positive we will go upwards
            //if the slope is negative we will go downwards
            int yIncr = slope >= 0 ? 1 : -1;

            float offset = 0;
            float threshold = 0.5f;

            if (slope >= -1 && slope <= 1)
            {
                float delta = Math.Abs(slope);
                int y = y1;
                if (x2 < x1)
                {
                    Utilities.Misc.Swap(ref x1, ref x2);
                    y = y2;
                }

                for (int x = x1; x <= x2; x++)
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
                if (y2 < y1)
                {
                    Utilities.Misc.Swap(ref y1, ref y2);
                    x = x2;
                }

                for (int y = y1; y <= y2; y++)
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
        public void mouseMove(Point mouseCoords)
        {
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
        private Point start;
    }
}
