using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicDesigner.Drawables
{
    class Rectangle : IDrawable
    {
        public IList<System.Drawing.PointF> GetPoints()
        {
            throw new NotImplementedException();
        }

        public void mouseDown(Point mouseCoords)
        {
            throw new NotImplementedException();
        }

        public void mouseUp(Point mouseCoords)
        {
            throw new NotImplementedException();
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
    }
}
