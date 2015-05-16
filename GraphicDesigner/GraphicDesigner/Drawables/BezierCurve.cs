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
            this.FigureType = FigureType.BezierCurve;
            this.NeedsConnectPoints = true;
            this.NeedsRemovePastLayer = true;
        }

        private IList<Point> ControlPoints { get; set; }
        private const double Step = 0.001;

        public override IList<Point> GetPoints()
        {
            var points = new List<Point>();
            if (this.ControlPoints.Count > 1)
            {
                for (double i = 0; i <= 1; i += Step)
                {
                    var point = C(i);
                    points.Add(point);
                }
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

        private Point C(double u)
        {
            double sumX = 0;
            double sumY = 0;
            int n = this.ControlPoints.Count - 1;

            for (int i = 0; i <= n; i++)
            {
                double Bniu = B(n, i, u);
                sumX += Bniu * this.ControlPoints.ElementAt(i).X;
                sumY += Bniu * this.ControlPoints.ElementAt(i).Y;
            }

            return new Point((int)sumX, (int)sumY);
        }

        private double B(int n, int i, double u)
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
