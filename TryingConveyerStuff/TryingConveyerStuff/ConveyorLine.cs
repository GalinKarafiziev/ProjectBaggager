using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryingConveyerStuff
{
    class ConveyorLine
    {
        LinkedList<Node> conveyerLine;
        List<Baggage> onConveyerLine;
        Node lastNode;

        public ConveyorLine(Node first, Node last) 
        {
            conveyerLine = new LinkedList<Node>();
            onConveyerLine = new List<Baggage>();
            conveyerLine.AddFirst(first);
            lastNode = last;
            conveyerLine.First().next = lastNode;
        }

        public void AddNodeToConveyer(Node data)
        {
            Node toAdd = data;

            Node current = conveyerLine.First();
            while (current.next != lastNode)
            {
                current = current.next;
            }
            toAdd.next = lastNode;
            current.next = toAdd;
        }

        public void SendBaggageDownConveyer(Baggage b)
        {
            onConveyerLine.Add(b);
        }

        public void DisplayEveryNode()
        {
            Node current = conveyerLine.First();
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

        public void MoveBelt()
        {
            // Notice .ToList() ! Later on in the loop, we remove items from onConveyerLine while we are still looping through it.
            // ToList() ensures that we can safely remove items without an error. 
            foreach (Baggage b in onConveyerLine.ToList())
            {
                MoveBaggage(b);
            }
        }

        void MoveBaggage(Baggage thisKufar)
        {
            Node current = conveyerLine.First();

            while (current.next != null)
            {
                if (current.baggageHeld != null && current.baggageHeld.baggageID == thisKufar.baggageID)
                {
                    if (current.next.baggageHeld == null)
                    {
                        current.next.baggageHeld = current.baggageHeld;
                        current.baggageHeld = null;
                    }

                    Console.SetCursorPosition(current.x, current.y);
                    Console.Write("|0|" + current.next.baggageHeld.baggageID);
                    break;
                }

                current = current.next;
            }
            if (current is DropOffPoint)
            {
                if (current.baggageHeld != null)
                {
                    Console.SetCursorPosition(current.x, current.y);
                    Console.Write("|0|");

                    onConveyerLine.Remove(current.baggageHeld);
                    DropOffPoint drop = (DropOffPoint) lastNode;
                    drop.AddBaggage(current.baggageHeld);

                    current.baggageHeld = null;
                }
            }
        }
    }
}
