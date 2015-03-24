using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicDesigner.Drawables
{
    class BezierCurve : Curve
    {
        public BezierCurve()
        {
            this.ControlPoints = new List<Point>();
        }

        private IList<Point> ControlPoints { get; set; }

        public override IList<Point> GetPoints()
        {
            var points = new List<Point>();

            for (int i = 0; i < this.ControlPoints.Count; i++)
            {
                // TODO
            }

            return points;
        }

        public override void mouseDown(Point mouseCoords)
        {
        }

        public override void mouseUp(Point mouseCoords)
        {
            this.ControlPoints.Add(mouseCoords);
        }

        public override void mouseMove(Point mouseCoords)
        {
            //throw new NotImplementedException();
        }

        private Point C(int u, IList<Point> points)
        {
            double sumX = 0;
            double sumY = 0;
            int n = points.Count;

            for (int i = 0; i < n; i++)
            {
                double Bniu = B(n, i, u);
                sumX += Bniu * points.ElementAt(i).X;
                sumY += Bniu * points.ElementAt(i).Y;
            }

            return new Point((int)sumX, (int)sumY);
        }

        private double B(int n, int i, int u)
        {
            return Binomial(n, i) * Math.Pow(u, i) * Math.Pow(1 - u, n - i);
        }

        private double Binomial(int n, int k)
        {
            if (k > n)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (k == 0)
            {
                return 1;
            }

            if (k > n / 2)
            {
                return Binomial(n, n - k);
            }

            return (double)n * Binomial(n - 1, k - 1) / k;
        }
    }
}
