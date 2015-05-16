using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicDesigner.Drawables
{
    class Ellipse : IDrawable
    {
        public Ellipse()
        {
            this.NeedsConnectPoints = false;
            this.NeedsRemovePastLayer = false;
        }

        public IList<Point> GetPoints()
        {
            var points = GeneratePoints();

            return points;
        }

        public void mouseDown(Point mouseCoords)
        {
            start = mouseCoords;
        }

        public IList<Point> GeneratePoints()
        {
            var points = new List<Point>();

            p1 = start;
            p2 = end;
            float a = Math.Abs((p2.X - p1.X) / 2);
            float b = Math.Abs((p1.Y- p2.Y) / 2);
            Point center = new Point();
            center.X = (p1.X + p2.X) / 2;
            center.Y = (p1.Y + p2.Y) / 2;

            int x1 = p1.X;
            int x2 = p2.X;
            int sign = 1;
            if( p1.X > p2.X)
            {
               // sign = -1;
                Utilities.Misc.Swap(ref x1, ref x2);
            }
            for (int i = x1; i < x2; i+=sign )
            {
                Point p3 = new Point();
                p3.X = i;
                p3.Y = EllipseEquation(i, 1, a, b,center);
                points.Add(p3);

                Point p4 = new Point();
                p4.X = i;
                p4.Y = EllipseEquation(i, -1, a, b, center);
                points.Add(p4);
            }


            if (start.X == end.X || start.Y == end.Y)
            {
                return points;
            }

            //AddLinePoints(p1, p4, ref points);
            //AddLinePoints(p4, p2, ref points);
            //AddLinePoints(p2, p3, ref points);
            //AddLinePoints(p3, p1, ref points);

            return points;
        }

        public int EllipseEquation(int x, int sign, float a, float b,Point center)
        {
            double result = 1 - ((x - center.X) * (x - center.X)) / (a * a);
            int y = (int)(sign * b * Math.Sqrt(result) + center.Y);
            return y;
        }
        public void AddLinePoints(Point p1, Point p2, ref List<Point> points)
        {
            Line l = new Line();
            l.GeneratePoints(p1, p2);
            for (int i = 0; i < l.GetPoints().Count; i++)
            {
                points.Add(l.GetPoints()[i]);
            }
        }
        public void mouseUp(Point mouseCoords)
        {
            end = mouseCoords;
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

        private Point start, end;
        private Point p1, p2, p3, p4;

        public bool NeedsRemovePastLayer { get; private set; }

        public bool NeedsConnectPoints { get; private set; }
    }
}
