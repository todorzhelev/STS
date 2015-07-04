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
        public Rotate()
        {
        }
        public Rotate(ref Renderer renderer)
        {
            this.renderer = renderer;
        }
        void setSelectedPoints(ref List<Point> sPoints)
        {

        }
        public IList<Point> GetPoints(ref IList<Point> selectedPoints,int cX, int cY)
        {
            var points = new List<Point>();

            for (int i = 0; i < selectedPoints.Count; i++)
            {
                if(this.renderer.currentDrawing.Get(selectedPoints[i].X,selectedPoints[i].Y) == Color.White)
                {
                    continue;
                }

                //save each non-white point
                Point p = new Point();
                p.X = selectedPoints[i].X;
                p.Y = selectedPoints[i].Y;
                points.Add(p);
            }

            //rotates each point counter-clockwise
            for (int i = 0; i < points.Count; i++)
            {
                int oldX = points[i].X - cX;
                int oldY = points[i].Y - cY;
                int newX = (int)(oldX * Math.Cos(rotationAngle) - oldY * Math.Sin(rotationAngle) + cX);
                int newY = (int)(oldX * Math.Sin(rotationAngle) + oldY * Math.Cos(rotationAngle) + cY);
                points[i] = new Point(newX, newY);
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

        private ToolType type;
        private Point start, end;
        private Renderer renderer;
        private static double rotationAngle = Math.PI/2;
    }
}
