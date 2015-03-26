using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicDesigner.Drawables
{
    class SplineCurve : Curve
    {
        public SplineCurve()
        {
            points = new List<Point>();
            ControlPoints = new List<Point>();
            nodes = new List<double>();
            this.curvePower = 1;
        }

        public override IList<System.Drawing.Point> GetPoints()
        {
            return points;
        }

        public override void mouseDown(System.Drawing.Point mouseCoords)
        {
        }

        public override void mouseUp(System.Drawing.Point mouseCoords)
        {
            ControlPoints.Add(mouseCoords);

            points.Add(mouseCoords);
            if (ControlPoints.Count > 1)
            {
                GeneratePoints();
            }

            //nodes.Add(0);
            //nodes.Add(0.25);
            //nodes.Add(0.5);
            //nodes.Add(0.75);
            //nodes.Add(1);

            //double result = N(1, 2, 0.9);

            //int a = 6;
        }

        public override void mouseMove(System.Drawing.Point mouseCoords)
        {
        }

        public void GeneratePoints()
        {
            nodes.Clear();
           
            int n = ControlPoints.Count-1;
            int m = n + curvePower+1;
            double step = 1 / (double)(m);

            for (double i = 0; i < 1; i += step)
            {
                nodes.Add(i);
            }

            nodes.Add(1);

            for (double i = 0; i < 1; i += 0.001)
            {
                Point p = C(i);
                points.Add(p);
            }

            points.Add(C(1));
        }
        public Point C(double u)
        {
            int n = ControlPoints.Count - 1 ;

            double x = 0, y = 0;

            for (int i = 0; i <= n; i++ )
            {
                double scalar = N(i, curvePower, u);
                Point p = ControlPoints[i];

                x += scalar* p.X;
                y += scalar* p.Y;
            }

            return new Point((int)x,(int)y);
        }

        public double N(int i, int p, double u)
        {
            if( p == 0 )
            {
                if( u > nodes[i] && u < nodes[i+1] || Math.Abs(u - nodes[i]) < 0.0001 )
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

            double leftSide = ((u - nodes[i]) / (nodes[i + p] - nodes[i])) * N(i, p - 1, u);
            double rightSide = ((nodes[i + p + 1] - u) / (nodes[i + p + 1] - nodes[i + 1])) * N(i + 1, p - 1, u);

            return leftSide+rightSide;
        }

        private IList<Point> points;
        private IList<Point> ControlPoints;
        private IList<double> nodes;
        private int curvePower;
    }
}
