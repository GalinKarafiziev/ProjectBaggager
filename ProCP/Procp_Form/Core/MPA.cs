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
        public List<Baggage> baggagesToWait;

        public MPA()
        {
            nextNodes = new List<Conveyor>();
            baggagesToWait = new List<Baggage>();
        }

        public void AddNextNode(Conveyor node)
        {
            var nextNode = node;
            nextNodes.Add(nextNode);
        }

        public override void ProcessBaggage()
        {
            foreach (var conv in nextNodes.ToList())
            {
                if (conv.DestinationGate == baggage.DestinationGate)
                {
                    NextNode = conv;
                    if (NextNode.Status == BaggageStatus.Free)
                    {
                        NextNode.PassBaggage(baggage);
                        Status = BaggageStatus.Free;
                        baggage = null;
                        if (OnNodeStatusChangedToFree != null)
                        {
                            NextNode.OnNodeStatusChangedToFree -= () => PassWaitingBaggage(conv);
                        }
                        break;
                    }
                    else
                    {
                        baggagesToWait.Add(baggage);
                        NextNode.OnNodeStatusChangedToFree += () => PassWaitingBaggage(conv);
                        break;
                    }
                }
            }
        }

        public void PassWaitingBaggage(Conveyor chosen)
        {
            var chosenConveyor = chosen;
            foreach (var bag in baggagesToWait)
            {
                if (bag != null)
                {
                    if (bag.DestinationGate == chosenConveyor.DestinationGate)
                    {
                        chosenConveyor.PassBaggage(bag);
                        Status = BaggageStatus.Free;
                        baggagesToWait.Remove(bag);
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
        }

        public override void PassBaggage(Baggage Lastbaggage)
        {
            baggage = Lastbaggage;
            Status = BaggageStatus.Busy;
            ProcessBaggage();
        }
    }
}
