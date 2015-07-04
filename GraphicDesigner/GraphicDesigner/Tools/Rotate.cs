using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicDesigner.Tools
{
    class Rotate : ITool
    {
        private static double rotationAngle = Math.PI / 2;

        public ToolType ToolType { get; set; }

        public Layer GetLayer(ref Layer selectedLayer, ref Renderer r)
        {
            var cx = selectedLayer.StartX + selectedLayer.Width / 2;
            var cy = selectedLayer.StartY + selectedLayer.Heigth / 2;
            var sxNew = cx - selectedLayer.Heigth / 2;
            var syNew = cy - selectedLayer.Width / 2;
            var exNew = cx + selectedLayer.Heigth / 2;
            var eyNew = cy + selectedLayer.Width / 2;
            if (sxNew < 0)
            {
                sxNew = 0;
            }
            if (syNew < 0)
            {
                syNew = 0;
            }

            var rotatedLayer = new Layer(sxNew, syNew, exNew, eyNew, Utilities.LayerLevel.Current);
            for (int i = selectedLayer.StartX; i <= selectedLayer.EndX; i++)
            {
                for (int j = selectedLayer.StartY; j <= selectedLayer.EndY; j++)
                {
                    int oldX = i - cx;
                    int oldY = j - cy;
                    int newX = (int)(oldX * Math.Cos(rotationAngle) - oldY * Math.Sin(rotationAngle) + cx);
                    int newY = (int)(oldX * Math.Sin(rotationAngle) + oldY * Math.Cos(rotationAngle) + cy);
                    if (newX < 0 || newY < 0)
                    {
                        continue;
                    }

                    rotatedLayer.Set(newX, newY, selectedLayer.Get(i, j));
                }
            }

            return rotatedLayer;
        }
  
        public void mouseDown(Point mouseCoords)
        {
        }

        public void mouseUp(Point mouseCoords, ref Renderer r)
        {
        }

        public void mouseMove(Point mouseCoords)
        {
        }
    }
}
