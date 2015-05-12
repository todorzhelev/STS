using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicDesigner.Tools
{
    class Rotate : ITool
    {
        void setSelectedPoints(ref List<Point> sPoints)
        {

        }
        public IList<Point> GetPoints(ref IList<Point> selectedPoints,int offsetX, int offsetY)
        {
            //double[,] mat = new double[2, 2];
            //mat[0, 0] = Math.Cos(10);
            //mat[0, 1] = Math.Sin(10);
            //mat[1, 0] = -Math.Sin(10);
            //mat[0, 1] = Math.Cos(10);
            var points = new List<Point>();
            double angle = 10;
            for (int i = 0; i < selectedPoints.Count; i++)
            {
                Point p = new Point();
               // double resultx = selectedPoints[i].X * Math.Cos(angle) - selectedPoints[i].Y * Math.Sin(angle);
                //p.X = (int)(1 * Math.Cos(angle) - 2 * Math.Sin(angle));
                //p.Y = (int)(1 * Math.Sin(angle) + 2 * Math.Cos(angle));
                p.X = (int)(selectedPoints[i].X * Math.Cos(angle) - selectedPoints[i].Y * Math.Sin(angle)+offsetX);
                p.Y = (int)(selectedPoints[i].X * Math.Sin(angle) + selectedPoints[i].Y * Math.Cos(angle)+offsetY);
                points.Add(p);
            }

            return points;
        }

        public IList<Point> GetPoints()
        {
            var points = new List<Point>();
 
            return points;
        }

    
        public void mouseDown(Point mouseCoords)
        {
            start = mouseCoords;
        }

        public Point GetCenter()
        {
            return new Point(0, 0);
        }

        public void mouseUp(Point mouseCoords, ref Renderer r)
        {
            end = mouseCoords;


        }

        public void mouseMove(Point mouseCoords)
        {
        }

        public ToolType ToolType
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }

        //private 
        private ToolType type;
        // public ToolType type;
        private Point start, end;
        private Point p1, p2, p3, p4;
    }
}
