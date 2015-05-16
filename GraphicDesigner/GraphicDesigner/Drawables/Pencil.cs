using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicDesigner.Drawables
{
    class Pencil : IDrawable
    {
        public Pencil()
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
            oldX = mouseCoords.X;
            oldY = mouseCoords.Y;
            isMouseDown = true;
            points = new List<Point>();

        }

        public void mouseUp(Point mouseCoords)
        {
            isMouseDown = false;
        }

        public void mouseMove(Point mouseCoords)
        {
            if( isMouseDown )
            {
                Line l = new Line();
                l.GeneratePoints(new Point(oldX, oldY), mouseCoords);
                for (int i = 0; i < l.GetPoints().Count; i++ )
                {
                    points.Add(l.GetPoints()[i]);
                }

                oldX = mouseCoords.X;
                oldY = mouseCoords.Y;
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
        private int oldX, oldY;
        public bool NeedsRemovePastLayer { get; private set; }

        public bool NeedsConnectPoints { get; private set; }
    }
}

