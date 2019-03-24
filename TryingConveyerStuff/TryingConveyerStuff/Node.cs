using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryingConveyerStuff
{
    public class Node
    {
        public Node next;
        public int x;
        public int y;

        public Node(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
