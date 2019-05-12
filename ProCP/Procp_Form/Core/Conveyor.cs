using Procp_Form.CoreAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procp_Form.Core
{
    public class Conveyor : TransportUnit
    {
        public Conveyor(int capacity, int timerSpeed) : base()
        {
            conveyorBelt.Capacity = capacity;
            timer.Interval = timerSpeed;
        }

        public override void Move()
        {
            this.Stop();

            if (CanMove())
            {
                if (lastBaggage != null)
                {
                    NextNode.PassBaggage(lastBaggage);
                }
            }

            for (int index = conveyorBelt.Capacity - 1; index < conveyorBelt.Capacity; index++ )
            {
                conveyorBelt[index] = conveyorBelt[index - 1];
                conveyorBelt[index - 1] = null;
            }

            NextNode.OnNodeStatusChangedToFree -= Move;
            Status = BaggageStatus.Free;
            this.Start();
        }

        public override void PassBaggage(Baggage lastbaggage)
        {
            Status = BaggageStatus.Busy;
            conveyorBelt.Add(lastbaggage);
        }
    }
}
