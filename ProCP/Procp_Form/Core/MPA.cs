using Procp_Form.CoreAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Procp_Form.Core
{
    public class MPA : ProcessUnit
    {
        public List<Conveyor> nextNodes;

        public MPA()
        {
            nextNodes = new List<Conveyor>();
        }

        public void AddNextNode(Conveyor node)
        {
            var nextNode = node;
            nextNodes.Add(nextNode);
        }

        public override void ProcessBaggage()
        {
            Status = BaggageStatus.Busy;

            if (baggage != null)
            {
                foreach (Conveyor conv in nextNodes)
                {
                    if (conv.FlightNumber == baggage.FlightNumber)
                    {
                        this.NextNode = conv;
                        NextNode.PassBaggage(baggage);
                        Thread.Sleep(800);
                        baggage = null;
                        Status = BaggageStatus.Free;
                        break;
                    }
                }
            }
        }

        public override void PassBaggage(Baggage Lastbaggage)
        {
            Status = BaggageStatus.Busy;
            baggage = Lastbaggage;
            ProcessBaggage();
        }
    }
}
