using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicDesigner.Drawables
{
    abstract class Curve : IDrawable
    {
        public abstract IList<Point> GetPoints();

        public abstract void mouseDown(Point mouseCoords);

        public abstract void mouseUp(Point mouseCoords);

        public abstract void mouseMove(Point mouseCoords);

        public FigureType FigureType { get; set; }

        public bool NeedsRemovePastLayer { get; protected set; }

        public bool NeedsConnectPoints { get; protected set; }
    }
}
