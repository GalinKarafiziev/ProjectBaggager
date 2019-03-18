using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP.ViewModels
{
    public abstract class Figure
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Size { get; protected set; }

        public Figure(int size, int x, int y)
        {
            this.Size = size;
            this.X = x;
            this.Y = y;
        }
    }
}
