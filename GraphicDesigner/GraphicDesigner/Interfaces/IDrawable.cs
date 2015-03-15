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
        IList<PointF> GetPoints();

        public FigureType FigureType { get; set; }
    }
}
