using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryingConveyerStuff
{
    class LinkedList
    {
        private Node head;

        
        public LinkedList(Node n)
        {
            head.x = n.x;
            head.y = n.y;
        }

        private void printList()
        {
            Node current = head;
            while(current != null)
            {
                Console.SetCursorPosition(head.x, head.y);
                Console.WriteLine("|  |");
                current = current.next;
            }
        }

        public void Add(Node data)
        {
            Node toAdd = data;

            Node current = head;
            while(current.next != null)
            {
                current = current.next;
            }
            current.next = toAdd;
        }

    }
}
