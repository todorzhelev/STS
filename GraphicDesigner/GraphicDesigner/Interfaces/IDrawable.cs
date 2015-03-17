using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicDesigner
{
    interface IDrawable
    {
        IList<Point> GetPoints();
        void mouseDown(Point mouseCoords);
        void mouseUp(Point mouseCoords);

        FigureType FigureType { get; set; }
    }
}
