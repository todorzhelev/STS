using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicDesigner
{
    enum FigureType
    {
        Line,
        Circle,
        Ellipse,
        Rectangle,
        Curve,
        BezierCurve,
        SplineCurve,
        Pencil,
        Eraser,
        Triangle,
        Square
    }

    enum ToolType
    {
        Unknown,
        Select,
        Rotate
    }
}
