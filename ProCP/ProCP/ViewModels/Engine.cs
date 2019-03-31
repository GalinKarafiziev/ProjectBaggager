using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Security security = new Security(2000);

        public Engine()
        {
            checkIn = new Checkin(1000);
            drop1 = new Dropoff();
            drop2 = new Dropoff();
            conveyorFromCheckin = new ConveyorLine();
            conveyorAfterSecurity = new ConveyorLine();
            conveyorToDropOff1 = new ConveyorLine();
            conveyorToDropOff2 = new ConveyorLine();
            mainProcessingUnit = new MainProcessArea(conveyorToDropOff1, conveyorToDropOff2);
            security = new Security(2000);
        }

        public void ConnectTheNodes()
        {
            checkIn.nextNode = conveyorFromCheckin;
            conveyorFromCheckin.nextNode = security;
            security.nextNode = conveyorAfterSecurity;
            conveyorAfterSecurity.nextNode = mainProcessingUnit;
            conveyorToDropOff1.nextNode = drop1;
            conveyorToDropOff2.nextNode = drop2;
        }
        public void AddBaggage()
        {
            Console.WriteLine("Number of baggage to be processed: ");
            int numberOfBaggage = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < numberOfBaggage; i++)
            {
                Baggage b = new Baggage();
                checkIn.PassBaggage(b);
            }
        }
    }
}
