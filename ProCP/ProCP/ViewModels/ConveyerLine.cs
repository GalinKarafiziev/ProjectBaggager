using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP.ViewModels
{
    public class ConveyerSlots : Figure
    {
        public ConveyerSlots(int size, Point position) : base(size, position)
        {
        }

        public ConveyerSlots(int size, int x, int y) : base(size, x, y)
        {
        }
    }
    public class ConveyerLine : Figure
    {
        LinkedList<ConveyerSlots> conveyerSlots;
        public IEnumerable<ConveyerSlots> Slots { get; protected set; }

        public ConveyerLine(int size, int x, int y) : base(size, x, y)
        {
            conveyerSlots = new LinkedList<ConveyerSlots>();
            for (int i = 0; i < size; i++)
            {
                conveyerSlots.AddFirst(new ConveyerSlots(5, x, y - (i * 5)));
            }
            this.Slots = conveyerSlots;
        }
    }
}
