using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicDesigner.Tools
{
    class Select : ITool
    {
        private Point start;
        private Point end;

        public ToolType ToolType { get; set; }
   
        public void mouseDown(Point mouseCoords)
        {
            this.start = mouseCoords;
        }


        public void mouseUp(Point mouseCoords, ref Renderer r)
        {
            this.end = mouseCoords;
        }

        public void mouseMove(Point mouseCoords)
        {
        }

        public Layer GetLayer(ref Layer selectedLayer, ref Renderer r)
        {
            var layer = new Layer(start.X, start.Y, end.X, end.Y, Utilities.LayerLevel.Current);
            for (int i = start.X; i <= end.X; i++)
            {
                for (int j = start.Y; j <= end.Y; j++)
                {
                    layer.Set(i, j, r.currentDrawing.Get(i, j));
                }
            }

            return layer;
        }
    }
}
