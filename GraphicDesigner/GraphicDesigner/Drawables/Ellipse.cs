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
            points = new List<Point>();
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

        public void mouseMove(Point mouseCoords)
        {
           
        }

        private void GeneratePoints()
        {
            points = new List<Point>();

            for (double i = 0; i < 360; i += 0.3)
            {
                double angle = i * System.Math.PI / 180;
                int x = (int)(cx + radius * System.Math.Cos(angle));
                int y = (int)(cy + radius * System.Math.Sin(angle));
                Point p = new Point(x, y);
                points.Add(p);
            }
        }

        public IList<Point> GetPoints()
        {
            return points;
        }

        public FigureType FigureType { get; set; }

        private IList<Point> points;
        private int cx, cy;
        private int radius;
    }
}
