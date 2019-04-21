using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProCP.models
{
    public class MainProcessArea: Node
    {
        public Baggage baggage { get; set; }
        public List<Node> nextNodes;

        public MainProcessArea()
        {
            nextNodes = new List<Node>();
        }
        public void AddNextNode(Node node)
        {
            var nextNode = node;
            nextNodes.Add(nextNode);
        }
        public void RedirectBaggage()
        {
            Status = BaggageStatus.Busy;

            if (baggage.DestinationGate == 1 || baggage.DestinationGate == 2)
            {
                if (NextNode.Status == BaggageStatus.Free)
                {
                    NextNode.PassBaggage(baggage);
                    Status = BaggageStatus.Free;
                }
                else
                {
                    RedirectBaggage();
                }
            }
            else
            {
                if (NextNode.Status == BaggageStatus.Free)
                {
                    convToDrop2.PassBaggage(baggage);
                    Status = BaggageStatus.Free;
                }
                else
                {
                    RedirectBaggage();
                }
            }
        }
        public override void PassBaggage(Baggage Lastbaggage)
        {
            baggage = Lastbaggage;
            RedirectBaggage();
        }
    }
}
