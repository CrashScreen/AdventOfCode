using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Rectangle
    {
        public int id;
        public int x;
        public int y;
        public int height;
        public int width;
        public bool isOverlapping;

        public int XRight
        {
            get
            {
                return x + width;
            }
        }

        public int YBottom
        {
            get
            {
                return y + height ;
            }
        }

        public Rectangle(int ID, int x, int y, int width, int height)
        {
            this.id = ID;
            this.x = x;
            this.y = y;
            this.height = height;
            this.width = width;
        }

        public bool isIntersecting(Rectangle rectangle)
        {
            if (x < rectangle.XRight && XRight > rectangle.x && y < rectangle.YBottom && YBottom > rectangle.y)
                return true;
            return false;
        }
    }
}
