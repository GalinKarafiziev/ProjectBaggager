using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP.ViewModels
{
    public class ConveyerSlots : Figure
    { 
        public ConveyerSlots(int size, int x, int y) : base(size, x, y)
        {
        }
    }
    public class ConveyerLine : Figure
    {
        public LinkedList<ConveyerSlots> conveyerSlots;
        public IEnumerable<ConveyerSlots> Slots { get; protected set; }

        public ConveyerLine(int size, int x, int y) : base(size, x, y)
        {
            conveyerSlots = new LinkedList<ConveyerSlots>();
            for (int i = 0; i < 5; i++)
            {
                conveyerSlots.AddFirst(new ConveyerSlots(40, x, y + i*40));
            }
            this.Slots = conveyerSlots;
        }
    }
}
