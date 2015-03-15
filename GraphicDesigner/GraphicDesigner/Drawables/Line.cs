using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicDesigner.Drawables
{
    class Line : IDrawable
    {
        public IList<System.Drawing.PointF> GetPoints()
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
