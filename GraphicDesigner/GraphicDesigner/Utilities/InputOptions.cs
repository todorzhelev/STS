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
        private ToolType toolType;

        public InputOptions(Color color, FigureType figureType, Utilities.BrushSize brushSize, ToolType toolType)
        {
            this.Color = color;
            this.FigureType = figureType;
            this.BrushSize = brushSize;
            this.ToolType = toolType;
        }

        public Color Color { get; set; }

        public IDrawable CurrentFigure { get; private set; }

        public ITool CurrentTool { get; private set; }

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

        public ToolType ToolType
        {
            get
            {
                return this.toolType;
            }

            set
            {
                this.toolType = value;
                this.CurrentTool = ToolFactory.GetTool(value);
            }
        }
    }
}
