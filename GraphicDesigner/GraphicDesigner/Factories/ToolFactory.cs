using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicDesigner
{
    static class ToolFactory
    {
        public static ITool GetTool(ToolType toolType)
        {
            switch (toolType)
            {
                case ToolType.Rotate:
                    return new Tools.Rotate();
                case ToolType.Select:
                    return new Tools.Select();
                case ToolType.Unknown:
                    return new Tools.Select();
                default:
                    return new Tools.Select();
            }
        }
    }
}
