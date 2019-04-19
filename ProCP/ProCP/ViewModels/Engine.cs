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
        public Checkin checkIn;
        public Dropoff drop1;
        public Dropoff drop2;
        public ConveyorLine conveyorFromCheckin;
        public ConveyorLine conveyorAfterSecurity;
        public ConveyorLine conveyorToDropOff1;
        public ConveyorLine conveyorToDropOff2;
        public MainProcessArea mainProcessingUnit;
        public SecurityUnit security = new SecurityUnit(2000);

        public Engine()
        {
            checkIn = new Checkin(1000);
            drop1 = new Dropoff();
            drop2 = new Dropoff();
            conveyorFromCheckin = new ConveyorLine(2500);
            conveyorAfterSecurity = new ConveyorLine(2500);
            conveyorToDropOff1 = new ConveyorLine(2500);
            conveyorToDropOff2 = new ConveyorLine(2500);
            mainProcessingUnit = new MainProcessArea(conveyorToDropOff1, conveyorToDropOff2);
            security = new SecurityUnit(2000);
        }

        public void ConnectTheNodes()
        {
            checkIn.NextNode = conveyorFromCheckin;
            conveyorFromCheckin.NextNode = security;
            security.NextNode = conveyorAfterSecurity;
            conveyorAfterSecurity.NextNode = mainProcessingUnit;
            conveyorToDropOff1.NextNode = drop1;
            conveyorToDropOff2.NextNode = drop2;
        }
        public void AddBaggage(int number)
        {
            var numberOfBaggage = number;

            for (int i = 0; i < numberOfBaggage; i++)
            {
                Baggage b = new Baggage();
                checkIn.PassBaggage(b);
            }
        }
    }
}
