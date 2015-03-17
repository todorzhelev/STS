using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicDesigner
{
    class InputOptions
    {
        private FigureType figureType;
        public InputOptions(Color color, FigureType figureType, Utilities.BrushSize brushSize)
        {
            this.Color = color;
            this.FigureType = figureType;
            this.BrushSize = brushSize;
        }

        public Color Color { get; set; }

        public IDrawable CurrentFigure { get; private set; }

        public Utilities.BrushSize BrushSize { get; set; }

        public FigureType FigureType
        {
            get 
            {
                return this.figureType;
            }

            set
            {
                this.figureType = value;
                this.CurrentFigure = DrawableFactory.GetDrawable(value);
            } 
        }
    }
}
