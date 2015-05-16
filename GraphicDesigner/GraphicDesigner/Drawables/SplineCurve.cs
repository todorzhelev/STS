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
        private const int MaxCurvePower = 3;
        public SplineCurve()
        {
          // file = new System.IO.StreamWriter(@"C:\Test\Test.txt");

            points = new List<Point>();
            ControlPoints = new List<Point>();
            nodes = new List<double>();
            this.curvePower = 3;

            this.NeedsConnectPoints = true;
            this.NeedsRemovePastLayer = true;
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
            if (ControlPoints.Count > MaxCurvePower)
            {
                GeneratePoints();
            }
        }

        public override void mouseMove(System.Drawing.Point mouseCoords)
        {
        }

        public void GeneratePoints()
        {
            nodes.Clear();
            points.Clear();

            int n = ControlPoints.Count-1;

            //if( n <= MaxCurvePower )
            //{
            //    //this.curvePower = n;
            //    return;
            //}
            //else
            //{
            //    this.curvePower = MaxCurvePower;
            //}
            int m = n + curvePower + 1;
                
            double step = 1 / (double)(m-2*curvePower);
          
            for (int i = curvePower; i >= 1; i--)
            {
                nodes.Add(-i * step);
            }

            for (double i = 0; i < 1; i += step)
            {
                nodes.Add(i);
            }

            nodes.Add(1);

            for (int i = 1; i <= curvePower; i++)
            {
                nodes.Add(1 + i * step);
            }

            for (double i = 0; i < 1; i += 0.001)
            {
                Point p = C(i);
                points.Add(p);
                //file.WriteLine("({0},{1})", p.X,p.Y);
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

                x += scalar* (double)p.X;
                y += scalar* (double)p.Y;
            }

            Point curvePoint = new Point((int)x, (int)y);
            //file.WriteLine("({0},{1})", curvePoint.X, curvePoint.Y);
            return curvePoint;
        }

        public double N(int i, int p, double u)
        {
            if( p == 0 )
            {
                if((u > nodes[i] && u < nodes[i+1]) || Math.Abs(u - nodes[i]) < 0.00001 )
                {
                    //file.WriteLine("u: {0} Ni: {1} Ni+1: {2}", u, nodes[i], nodes[i + 1]);
                    //double value = 1/(nodes[i+1]-nodes[i]);
                    return 1;
                }
                else
                {
                    //file.WriteLine("u: {0} Ni: {1} Ni+1: {2}", u, nodes[i], nodes[i + 1]);
                    return 0;
                }
            }
            else
            {
                double A = (u - nodes[i]) / (nodes[i + p] - nodes[i]);
                double leftSide = A * N(i, p - 1, u);

                double B = (nodes[i + p + 1] - u) / (nodes[i + p + 1] - nodes[i+1]);
                double rightSide = B * N(i + 1, p - 1, u);

                //file.WriteLine("N{0},{1}({2}) = {3}", i,p,u,leftSide+rightSide);

                return leftSide + rightSide;
            }
        }

        private IList<Point> points;
        private IList<Point> ControlPoints;
        private IList<double> nodes;
        private int curvePower;
        private System.IO.StreamWriter file;
    }
}
