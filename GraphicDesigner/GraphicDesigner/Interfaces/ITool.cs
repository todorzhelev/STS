using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicDesigner
{
    interface ITool
    {
        Layer GetLayer(ref Layer selectedLayer, ref Renderer r);
        void mouseDown(Point mouseCoords);
        void mouseUp(Point mouseCoords, ref Renderer r);
        void mouseMove(Point mouseCoords);
        ToolType ToolType { get; set; }
    }
}
