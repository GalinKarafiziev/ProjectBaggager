using Procp_Form.CoreAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Procp_Form.Core
{
    public class Conveyor : TransportUnit
    {
        public int DestinationGate { get; set; }

        public Conveyor(int capacity, int timerSpeed) : base()
        {
            timer.Interval = timerSpeed;
            conveyorBelt = new Baggage[capacity];
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
                else
                {
                    NextNode.OnNodeStatusChangedToFree += Move;
                }
            }

            for (int index = conveyorBelt.Length - 1; index > 0; index--)
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
            conveyorBelt[0] = lastbaggage;
        }
    }
}
