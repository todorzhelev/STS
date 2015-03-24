using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicDesigner
{
    static class DrawableFactory
    {
        public static IDrawable GetDrawable(FigureType figureType)
        {
            switch (figureType)
            {
                case FigureType.Line:
                    return new Drawables.Line();
                case FigureType.Ellipse:
                    return new Drawables.Ellipse();
                case FigureType.Rectangle:
                    return new Drawables.Rectangle();
                case FigureType.BezierCurve:
                    return new Drawables.BezierCurve();
                case FigureType.SplineCurve:
                    return new Drawables.SplineCurve();
                case FigureType.Pencil:
                    return new Drawables.Pencil();
                default:
                    return new Drawables.Line();
            }
        }
    }
}
