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
                if( this.renderer.currentDrawing.ColorMatrix.Get(selectedPoints[i].X,selectedPoints[i].Y) == Color.White)
                {
                    continue;
                }

                //translates each non-white point to the beginning of the coordinate system
                Point p = new Point();
                p.X = selectedPoints[i].X - cX;
                p.Y = selectedPoints[i].Y - cY;
                points.Add(p);
            }

            //rotates each point counter-clockwise
            for (int i = 0; i < points.Count; i++)
            {
                int x = (int)(points[i].X * Math.Cos(rotationAngle) + points[i].Y * Math.Sin(rotationAngle));
                int y = (int)(-points[i].X * Math.Sin(rotationAngle) + points[i].Y * Math.Cos(rotationAngle));
                points[i] = new Point(x, y);
            }

            //returns back the points
            for (int i = 0; i < points.Count; i++)
            {
                int x = points[i].X + cX;
                int y = points[i].Y + cY;
                points[i] = new Point(x,y);
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
        private static int rotationAngle = 45;
    }
}
