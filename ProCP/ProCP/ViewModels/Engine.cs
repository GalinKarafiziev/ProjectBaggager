using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProCP.models;

namespace ProCP.viewModels
{
    public class Engine
    {
        public Checkin checkInFirst;
        public Dropoff drop1;
        public Dropoff drop2;
        public ConveyorLine conveyorFromCheckinFirst;
        public ConveyorLine conveyorAfterSecurity;
        public ConveyorLine conveyorToDropOff1;
        public ConveyorLine conveyorToDropOff2;
        public MainProcessArea mainProcessingUnit;
        public SecurityUnit security = new SecurityUnit(2000);

        public Engine()
        {
            checkInFirst = new Checkin(1000);
            drop1 = new Dropoff(1);
            drop2 = new Dropoff(2);
            conveyorFromCheckinFirst = new ConveyorLine(2500);
            conveyorAfterSecurity = new ConveyorLine(2500);
            mainProcessingUnit = new MainProcessArea();
            security = new SecurityUnit(2000);
        }

        public void ConnectTheNodes()
        {
            checkInFirst.NextNode = conveyorFromCheckinFirst;
            conveyorFromCheckinFirst.NextNode = security;
            security.NextNode = conveyorAfterSecurity;
            conveyorAfterSecurity.NextNode = mainProcessingUnit;
            mainProcessingUnit.AddNextNode(drop1);
            mainProcessingUnit.AddNextNode(drop2);
        }
        public void AddBaggage(int number)
        {
            var numberOfBaggage = number;

            for (int i = 0; i < numberOfBaggage; i++)
            {
                Baggage b = new Baggage();
                checkInFirst.PassBaggage(b);
            }
        }
    }
}
