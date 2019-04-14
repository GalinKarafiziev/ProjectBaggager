using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProCP.viewModels
{
    public class MainProcessArea: Node
    {
        public Baggage baggage { get; set; }
        ConveyorLine convToDrop1;
        ConveyorLine convToDrop2;
        public MainProcessArea(ConveyorLine convToDropOne, ConveyorLine convToDropTwo)
        {
            this.convToDrop1 = convToDropOne;
            this.convToDrop2 = convToDropTwo;
        }

        public void RedirectBaggage()
        {
            Status = BaggageStatus.Busy;

            if (baggage.DestinationGate == 1 || baggage.DestinationGate == 2)
            {
                Thread.Sleep(1000);
                nextNode = convToDrop1;
                if (nextNode.Status == BaggageStatus.Free)
                {
                    convToDrop1.PassBaggage(baggage);
                    Status = BaggageStatus.Free;
                }
                else
                {
                    RedirectBaggage();
                }
            }
            else
            {
                Thread.Sleep(1000);
                nextNode = convToDrop2;
                if (nextNode.Status == BaggageStatus.Free)
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
