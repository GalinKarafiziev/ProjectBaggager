using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP.ViewModels
{
    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    public abstract class Figure
    {
        public int Size { get; protected set; }
        public Point Position { get; protected set; }

        public Figure(int size, int x, int y) : this(size, new Point() { X = x, Y = y })
        {

        }
        public Figure(int size, Point position)
        {
            this.Size = size;
            this.Position = position;
        }
    }
}
