using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Test
{
    public class MainProcessingUnit : Node
    {
        public Baggage baggage;
        ConveyerLine convToDrop1;
        ConveyerLine convToDrop2;
        public MainProcessingUnit(ConveyerLine convToDropOne, ConveyerLine convToDropTwo)
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