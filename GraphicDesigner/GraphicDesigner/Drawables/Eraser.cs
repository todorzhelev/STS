using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicDesigner.Drawables
{
    class Eraser : IDrawable
    {
        public Eraser()
        {
            points = new List<Point>();
            this.NeedsConnectPoints = false;
            this.NeedsRemovePastLayer = false;
        }

        public IList<Point> GetPoints()
        {
            return points;
        }

        public void mouseDown(Point mouseCoords)
        {
            oldPoint = mouseCoords;

            isMouseDown = true;
            points = new List<Point>();

        }

        public void mouseUp(Point mouseCoords)
        {
            isMouseDown = false;
        }

        public void mouseMove(Point mouseCoords)
        {
            if (isMouseDown)
            {
                Line l = new Line();
                l.GeneratePoints(new Point(oldPoint.X, oldPoint.Y), mouseCoords);
                for (int i = 0; i < l.GetPoints().Count; i++)
                {
                    points.Add(l.GetPoints()[i]);
                }

                oldPoint = mouseCoords;
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

        private IList<Point> points;
        private bool isMouseDown;
        private Point oldPoint;

        public bool NeedsRemovePastLayer { get; private set; }

        public bool NeedsConnectPoints { get; private set; }
    }
}
