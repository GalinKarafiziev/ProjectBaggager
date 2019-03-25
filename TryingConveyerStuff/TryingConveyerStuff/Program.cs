using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TryingConveyerStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            CheckInDesk checkInOne = new CheckInDesk(3, 3, 3);
            DropOffPoint dropOffOne = new DropOffPoint(3, 12);

            ConveyorLine firstConveyor = new ConveyorLine(checkInOne, dropOffOne);

            List<CheckInDesk> checkInDesks = new List<CheckInDesk>();
            List<DropOffPoint> dropOffPoints = new List<DropOffPoint>();
            List<ConveyorLine> conveyorLines = new List<ConveyorLine>(); 

            // adding baggage to check in desk one
            checkInOne.AddBaggage("b001");
            checkInOne.AddBaggage("b002");
            checkInOne.AddBaggage("b003");
            checkInOne.AddBaggage("b004");
            checkInOne.AddBaggage("b005t");

            //adding desks to the check in desk
            checkInDesks.Add(checkInOne);

            //creating and starting the timer
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(TimerSequence);
            aTimer.Interval = 1000;
            aTimer.Enabled = true;


            // Method called every timer interval
            void TimerSequence(object source, ElapsedEventArgs e)
            {
                Console.Clear();
                DisplayEveryNode();
                LoadConveyer();
                MoveBelts();
                DisplayDropOffInfo();
                DisplayCheckInInfo();
            }

            //Only creating the conveyer belt really... probably should include adding check-in desks, baggages etc in here
            Initialize();

            // Methods 
            void Initialize()
            {
                conveyorLines.Add(firstConveyor);

                firstConveyor.AddNodeToConveyer(new Node(3, 4));
                firstConveyor.AddNodeToConveyer(new Node(3, 5));
                firstConveyor.AddNodeToConveyer(new Node(3, 6));
                firstConveyor.AddNodeToConveyer(new Node(3, 7));
                firstConveyor.AddNodeToConveyer(new Node(3, 8));
                firstConveyor.AddNodeToConveyer(new Node(3, 9));
                firstConveyor.AddNodeToConveyer(new Node(3, 10));
                firstConveyor.AddNodeToConveyer(new Node(3, 11));

               // firstConveyor.AddNodeToConveyer(dropOffOne);
            }

            //in this method, should more than one check-in desks exist, one must check if there are two baggages released at the same time
            void LoadConveyer()
            {
                foreach (CheckInDesk d in checkInDesks)
                {
                    d.timer += 1;
                    if(d.timer >= d.interval && d.HasBaggages())
                    {
                        firstConveyor.SendBaggageDownConveyer(d.SendBaggage());
                        d.timer = 0;
                    }
                }
            }

            void MoveBelts()
            {
                firstConveyor.MoveBelt();
            }


            void DisplayEveryNode()
            {
                foreach (ConveyorLine l in conveyorLines)
                {
                    l.DisplayEveryNode();
                }
            }
        
            void DisplayDropOffInfo()
            {
                Console.SetCursorPosition(3, 16);
                Console.Write("Luggages in drop-off:");

                int drY = 17;
                foreach(string s in dropOffOne.ShowBaggages())
                {
                    Console.SetCursorPosition(3, drY);
                    Console.Write(s);
                    drY += 1;
                }
            }

            void DisplayCheckInInfo()
            {
                Console.SetCursorPosition(32, 2);
                Console.Write("Check-in baggages:");

                int chY = 3;
                foreach(string s in checkInOne.ShowBaggages())
                {
                    Console.SetCursorPosition(32, chY);
                    Console.Write(s);
                    chY += 1;
                }
            }


            Console.ReadKey();
        }
    }
}
