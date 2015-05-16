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
            double angle = 50;


            for (int i = 0; i < selectedPoints.Count; i++)
            {
                if( this.renderer.currentDrawing.colorMatrix.matrix[selectedPoints[i].X,selectedPoints[i].Y] == Color.White)
                {
                    continue;
                }

                Point p = new Point();
                p.X = selectedPoints[i].X - cX;
                p.Y = selectedPoints[i].Y - cY;
                points.Add(p);
            }

            for (int i = 0; i < points.Count; i++)
            {
                int x = (int)(points[i].X * Math.Cos(angle) - points[i].Y * Math.Sin(angle));
                int y = (int)(points[i].X * Math.Sin(angle) + points[i].Y * Math.Cos(angle));
                points[i] = new Point(x, y);
            }

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

        //private 
        private ToolType type;
        // public ToolType type;
        private Point start, end;
        private Point p1, p2, p3, p4;
        private Renderer renderer;
    }
}
