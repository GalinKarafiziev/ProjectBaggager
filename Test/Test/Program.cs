using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            CheckInDesk checkIn = new CheckInDesk(1000);
            DropOff drop1 = new DropOff();
            DropOff drop2 = new DropOff();
            ConveyerLine conveyorFromCheckin = new ConveyerLine();
            ConveyerLine conveyorAfterSecurity = new ConveyerLine();
            ConveyerLine conveyorToDropOff1 = new ConveyerLine();
            ConveyerLine conveyorToDropOff2 = new ConveyerLine();
            MainProcessingUnit mainProcessingUnit = new MainProcessingUnit(conveyorToDropOff1, conveyorToDropOff2);
            Security sec = new Security(2000);

            checkIn.nextNode = conveyorFromCheckin;
            conveyorFromCheckin.nextNode = sec;
            sec.nextNode = conveyorAfterSecurity;
            conveyorAfterSecurity.nextNode = mainProcessingUnit;
            conveyorToDropOff1.nextNode = drop1;
            conveyorToDropOff2.nextNode = drop2;

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
