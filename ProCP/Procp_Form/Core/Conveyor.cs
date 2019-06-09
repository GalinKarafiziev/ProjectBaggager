using Procp_Form.CoreAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Procp_Form.Core
{
    [Serializable]
    public class Conveyor : TransportUnit
    {
        public int DestinationGate { get; set; }

        public int conveyorSpeed;

        public int ConveyorSpeed
        {
            get
            {
                return conveyorSpeed;
            }
            set
            {
                switch (conveyorSpeed)
                {
                    case 1:
                        timer.Interval = 500;
                        break;
                    case 2:
                        timer.Interval = 800;
                        break;
                    case 3:
                        timer.Interval = 1000;
                        break;
                    case 4:
                        timer.Interval = 1200;
                        break;
                    default:
                        timer.Interval = 500;
                        break;
                }
            }
        }

        public Conveyor(int capacity, int timerSpeed) : base()
        {
            ConveyorSpeed = timerSpeed;
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

                for (int index = conveyorBelt.Length - 1; index > 0; index--)
                {
                    conveyorBelt[index] = conveyorBelt[index - 1];
                    conveyorBelt[index - 1] = null;
                }
            }
            else
            {
                NextNode.OnNodeStatusChangedToFree += Move;
                return;
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
