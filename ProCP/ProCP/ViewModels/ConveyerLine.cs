using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP.ViewModels
{
    public class ConveyerLine : Figure
    {
        public LinkedList<ConveyerSlot> conveyerSlots;
        public IEnumerable<ConveyerSlot> Slots { get; protected set; }

        public ConveyerLine(int size, int x, int y) : base(size, x, y)
        {
            conveyerSlots = new LinkedList<ConveyerSlot>();
            for (int i = 0; i < 7; i++)
            {
                conveyerSlots.AddFirst(new ConveyerSlot(40, x + (i*40), y));
            }
            this.Slots = conveyerSlots;
        }
    }
}
