using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryingConveyerStuff
{
    public class CheckInDesk : Node
    {
        List<Baggage> baggages;

        //are there any baggages to be checked in
        bool hasBaggage;

        //baggage is ready to be sent
        bool baggageReady;

        //increases every interval of the timer
        public int timer;

        //the interval in which the baggage will be sent down the conveyer line
        public int interval; 

        public CheckInDesk(int x, int y, int i) : base(x, y)
        {
            baggages = new List<Baggage>();
            hasBaggage = false;
            baggageReady = false;
            interval = i;
        }

        public bool HasBaggage()
        {
            return hasBaggage;
        }

        //the location of the baggage is the location of the desk
        public void AddBaggage(string id)
        {
            Baggage b = new Baggage(this.x, this.y, id);
            baggages.Add(b);
            hasBaggage = true;
            timer = 0;
        }

        public Baggage SendBaggage()
        {
            Baggage send = baggages.First();
            baggages.RemoveAt(0);
            
            if(!baggages.Any())
            {
                hasBaggage = false;
               
            }            
            return send;
        }
       
        public List<string> ShowBaggages()
        {
            List<string> baggageIDs = new List<string>();
            foreach (Baggage i in baggages)
            {
                baggageIDs.Add(i.baggageID);
            }
            return baggageIDs;
        }

        public int BaggageAmount()
        {
            return baggages.Count;
        }
    }
}
