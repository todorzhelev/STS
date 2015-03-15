using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicDesigner.Drawables
{
    class Line : IDrawable
    {
        public Line()
        {
            points = new List<PointF>();
        }

        public IList<System.Drawing.PointF> GetPoints()
        {
            return points;
        }

        public void mouseDown(Point mouseCoords)
        {
            sx = mouseCoords.X;
            sy = mouseCoords.Y;
        }

        public void mouseUp(Point mouseCoords)
        {
            Point p1 = new Point(sx, sy);
            Point p2 = new Point(mouseCoords.X, mouseCoords.Y);

            double deltaX = p2.X - p1.X;
            double deltaY = p2.Y - p1.Y;
            double error = 0;
            double deltaError = Math.Abs(deltaY / deltaX);

            int y = p1.Y;
            for( int x = p1.X; x <= p2.X; x++ )
            {
                points.Add(new Point(x,y));
                error += deltaError;

                while( error >= 0.5 )
                {
                    points.Add(new Point(x, y));
                    y += Math.Sign(p2.Y - p1.Y);
                    error -= 1;
                }
            }
        }

        public FigureType FigureType
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        private IList<PointF> points;
        private int sx, sy;
    }
}
