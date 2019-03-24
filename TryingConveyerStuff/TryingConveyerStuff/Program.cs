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

            LinkedList<Node> conveyerLine = new LinkedList<Node>();
            List<Baggage> onConveyerLine = new List<Baggage>();
            List<CheckInDesk> checkInDesks = new List<CheckInDesk>();
            List<DropOffPoint> dropOffPoints = new List<DropOffPoint>(); 

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
                MoveBelt();
                DisplayDropOffInfo();
                DisplayCheckInInfo();
            }



            //Only creating the conveyer belt really... probably should include adding check-in desks, baggages etc in here
            Initialize();

            // Methods 
            void Initialize()
            {
                conveyerLine.AddFirst(checkInOne);
                
                AddNodeToConveyer(new Node(3, 4));
                AddNodeToConveyer(new Node(3, 5));
                AddNodeToConveyer(new Node(3, 6));
                AddNodeToConveyer(new Node(3, 7));
                AddNodeToConveyer(new Node(3, 8));
                AddNodeToConveyer(new Node(3, 9));
                AddNodeToConveyer(new Node(3, 10));
                AddNodeToConveyer(new Node(3, 11));

                AddNodeToConveyer(dropOffOne);
            }

            void AddNodeToConveyer(Node data)
            {
                Node toAdd = data;

                Node current = checkInOne;
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = toAdd;
            }

            void DisplayEveryNode()
            {
                Node current = checkInOne;
                while (current.next != null)
                {
                    Console.SetCursorPosition(current.x, current.y);
                    Console.Write("| |");
                    current = current.next;
                }

                //drop off point
                Console.SetCursorPosition(current.x, current.y);
                Console.Write("| |");
            }

            //in this method, should more than one check-in desks exist, one must check if there are two baggages released at the same time
            void LoadConveyer()
            {
                foreach (CheckInDesk d in checkInDesks)
                {
                    d.timer += 1;
                    if(d.timer >= d.interval && d.HasBaggage())
                    {
                        onConveyerLine.Add(d.SendBaggage());
                        d.timer = 0;
                    }
                }
            }

            void MoveBelt()
            {
                // Notice .ToList() ! Later on in the loop, we remove items from onConveyerLine while we are still looping through it.
                // ToList() ensures that we can safely remove items without an error. 
                foreach(Baggage b in onConveyerLine.ToList())
                {
                    MoveBaggage(b);
                }
            }

            void MoveBaggage(Baggage thisKufar)
            {
                Node current = checkInOne;

                while (current.next != null)
                {
                    if (thisKufar.x == current.x && thisKufar.y == current.y)
                    {
                        thisKufar.x = current.next.x;
                        thisKufar.y = current.next.y;

                        Console.SetCursorPosition(current.x, current.y);
                        Console.Write("|0|" + thisKufar.baggageID);
                        break;
                    }
                    else
                    {
                        current = current.next;
                    }
                }
                if (current is DropOffPoint)
                {
                    if (thisKufar.x == current.x && thisKufar.y == current.y)
                    {
                        Console.SetCursorPosition(current.x, current.y);
                        Console.Write("|0|");

                        onConveyerLine.Remove(thisKufar);
                        dropOffOne.AddBaggage(thisKufar);
                    }
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
