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
        public Baggage baggage;
        ConveyorLine convToDrop1;
        ConveyorLine convToDrop2;
        public MainProcessArea(ConveyorLine convToDropOne, ConveyorLine convToDropTwo)
        {
            this.convToDrop1 = convToDropOne;
            this.convToDrop2 = convToDropTwo;
        }
        public override void PassBaggage(Baggage Lastbaggage)
        {
            baggage = Lastbaggage;
            if (baggage.DestinationGate == 1 || baggage.DestinationGate == 2)
            {
                Thread.Sleep(1000);
                nextNode = convToDrop1;
                convToDrop1.PassBaggage(Lastbaggage);
            }
            else
            {
                Thread.Sleep(1000);
                nextNode = convToDrop2;
                convToDrop2.PassBaggage(Lastbaggage);
            }
        }
    }
}
