using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicDesigner.Drawables
{
    class Ellipse : IDrawable
    {
        public Ellipse()
        {
        }

        public Ellipse(int radius)
        {
            this.radius = radius;
        }

        public void mouseDown(Point mouseCoords)
        {
            cx = mouseCoords.X;
            cy = mouseCoords.Y;
        }

        public void mouseUp(Point mouseCoords)
        {
            Point p1 = new Point(cx, cy);
            Point p2 = new Point(mouseCoords.X, mouseCoords.Y);
            double distance = Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
            radius = (int)distance;

            GeneratePoints();
        }

        private void GeneratePoints()
        {
            points = new List<PointF>();

            for (double i = 0; i < 360; i += 0.3)
            {
                double angle = i * System.Math.PI / 180;
                int x = (int)(cx + radius * System.Math.Cos(angle));
                int y = (int)(cy + radius * System.Math.Sin(angle));
                Point p = new Point(x, y);
                points.Add(p);
            }
        }
        public IList<PointF> GetPoints()
        {
            return points;
        }

        private IList<PointF> points;
        private int cx,cy;
        private int radius;


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
    }
}
