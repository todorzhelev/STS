using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicDesigner.Tools
{
    class Select : ITool
    {
        public IList<Point> GetPoints()
        {
            var points = new List<Point>();
            for (int i = start.X; i < end.X; i++)
            {
                for (int j = start.Y; j < end.Y; j++)
                {
                    points.Add(new Point(i, j));
                }

            }

            return points;
        }

        public void mouseDown(Point mouseCoords)
        {
            start = mouseCoords;
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

        void setSelectedPoints(ref List<Point> sPoints)
        {

        }

        public Point GetCenter()
        {
            return new Point(start.X+Math.Abs(end.X - start.X) / 2, start.Y+Math.Abs(end.Y - start.Y) / 2);
        }

        private ToolType type;
       // public ToolType type;
        private Point start,end;
        private Point p1, p2, p3, p4;
    }
}
