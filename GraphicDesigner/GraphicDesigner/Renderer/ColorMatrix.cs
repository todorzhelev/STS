using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicDesigner
{
    public class ColorMatrix
    {
        public int StartX { get; private set; }
        public int StartY { get; private set; }
        public int EndX { get; private set; }
        public int EndY { get; private set; }
        public int Width { get; private set; }
        public int Heigth { get; private set; }

        private Color[,] matrix;

        public ColorMatrix(int startX, int startY, int endX, int endY)
        {
            this.StartX = startX;
            this.StartY = startY;
            this.EndX = endX;
            this.EndY = endY;
            this.Width = endX - startX + 1;
            this.Heigth = endY - startY + 1;

            this.matrix = new Color[this.Width, this.Heigth];

            for (int i = 0; i < this.Width; i++)
            {
                for (int j = 0; j < this.Heigth; j++)
                {
                    this.matrix[i, j] = Color.White;
                }
            }
        }

        public Color Get(int x, int y)
        {
            if (x < StartX || x > EndX)
            {
                throw new ArgumentOutOfRangeException("X", x, "X should be between " + StartX + " and " + EndX);
            }
            if (y < StartY || y > EndY)
            {
                throw new ArgumentOutOfRangeException("Y", y, "Y should be between " + StartY + " and " + EndY);
            }

            return this.matrix[x - StartX, y - StartY];
        }

        public void Set(int x, int y, Color color)
        {
            if (x < StartX || x > EndX)
            {
                throw new ArgumentOutOfRangeException("X", x, "X should be between " + StartX + " and " + EndX);
            }
            if (y < StartY || y > EndY)
            {
                throw new ArgumentOutOfRangeException("Y", y, "Y should be between " + StartY + " and " + EndY);
            }

            this.matrix[x - StartX, y - StartY] = color;
        }

        public void SetMultiple(ColorMatrix other)
        {
            for (int i = other.StartX; i <= other.EndX; i++)
            {
                for (int j = other.StartY; j <= other.EndY; j++)
                {
                    if (i < this.EndX && j < this.EndY)
                    {
                        this.Set(i, j, other.Get(i, j));
                    }
                }
            }
        }

        public ColorMatrix Clone()
        {
            ColorMatrix clone = new ColorMatrix(this.StartX, this.StartY, this.EndX, this.EndY);
            return clone;
        }
    }
}
