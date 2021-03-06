﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicDesigner.Drawables
{
    class Triangle : IDrawable
    {
        public Triangle()
        {
            this.NeedsConnectPoints = false;
            this.NeedsRemovePastLayer = false;
        }

        public IList<Point> GetPoints()
        {
            var points = GeneratePoints();

            return points;
        }

        public void mouseDown(Point mouseCoords)
        {
            start = mouseCoords;
        }

        public IList<Point> GeneratePoints()
        {
            var points = new List<Point>();

            p1 = start;
            p2 = end;
            p3 = new Point(p1.X, p2.Y);
            p4 = new Point((p1.X + p2.X)/2, p1.Y);

            if(start.X == end.X || start.Y == end.Y)
            {
                return points;
            }

            AddLinePoints(p4, p2,  ref points);
            AddLinePoints(p2, p3,  ref points);
            AddLinePoints(p4, p3,  ref points);

            return points;
        }

        public void AddLinePoints(Point p1, Point p2, ref List<Point> points)
        {
            Line l = new Line();
            l.GeneratePoints(p1, p2);
            points.AddRange(l.GetPoints());
        }
        public void mouseUp(Point mouseCoords)
        {
            end = mouseCoords;
        }

        public void mouseMove(Point mouseCoords)
        {
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

        private Point start,end;
        private Point p1, p2, p3, p4;

        public bool NeedsRemovePastLayer { get; private set; }

        public bool NeedsConnectPoints { get; private set; }
    }
}
