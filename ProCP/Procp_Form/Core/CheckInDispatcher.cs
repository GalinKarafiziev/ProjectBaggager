using Procp_Form.Airport;
using Procp_Form.CoreAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Procp_Form.Core
{
    [Serializable]
    public class CheckInDispatcher : Node
    {
        [NonSerialized]
        Timer timer;
        public List<Queue<Baggage>> checkinQueues;
        public List<Timer> timers;
        public List<CheckIn> checkins;

        public CheckInDispatcher()
        {
            checkins = new List<CheckIn>();
            checkinQueues = new List<Queue<Baggage>>();
        }

        public List<CheckIn> GetCheckIns()
        {
            return this.checkins;
        }

        public List<Queue<Baggage>> GetQueuedBaggage()
        {
            return checkinQueues;
        }

        public void Start()
        {
            foreach (Timer t in timers)
            {
                t.Start();
            }
        }

        public void Stop()
        {
            foreach (Timer t in timers)
            {
                t.Stop();
            }
        }

        public void DispatchBaggage(Flight flight)
        {
            var baggage = new Baggage();
            baggage.DestinationGate = flight.DestinationGate;
            int chosen = FindMostSuitableCheckin(baggage);
            var checkIn = checkins[chosen];
            var queue = checkinQueues[chosen];


            if (checkIn.Status == BaggageStatus.Free)
            {
                checkIn.PassBaggage(baggage);
                if (OnNodeStatusChangedToFree != null)
                {
                    checkIn.OnNodeStatusChangedToFree -= () => PassQueuedBaggage(chosen);
                }
            }
            else
            {
                queue.Enqueue(baggage);
                checkIn.OnNodeStatusChangedToFree += () => PassQueuedBaggage(chosen);
            }
            flight.BaggageDispatched++;
        }

        public void PassQueuedBaggage(int index)
        {
            var checkIn = checkins[index];
            var queue = checkinQueues[index];

            if (queue.Count != 0)
            {
                checkIn.PassBaggage(queue.Dequeue());
            }
        }

        public void SetupCheckins(List<CheckIn> checkinDesks)
        {
            foreach (CheckIn desk in checkinDesks)
            {
                checkins.Add(desk);
            }
            this.SetupQueues();
        }

        public void SetupQueues()
        {
            foreach (int i in Enumerable.Range(0, checkins.Count))
            {
                checkinQueues.Add(new Queue<Baggage>());
            }
        }

        public void SetupTimers(List<Flight> flights)
        {
            timers = new List<Timer>();

            foreach (Flight f in flights)
            {
                timer = new Timer();
                timers.Add(timer);
                timer.Interval = 1000;

                timer.Elapsed += (sender, args) =>
                {
                    if (f.AmountOfBaggage > f.BaggageDispatched)
                    {
                        DispatchBaggage(f);
                    }
                    else
                    {
                        timer.Stop();
                    }
                };
            }
        }

        public int FindMostSuitableCheckin(Baggage baggage)
        {
            int chosenIndex = 0;

            foreach (var checkIn in Enumerable.Range(0, checkins.Count))
            {
                if (checkins.ElementAt(checkIn).DestinationGate == baggage.DestinationGate)
                {
                    if (checkins.ElementAt(checkIn).Status == BaggageStatus.Free)
                    {
                        chosenIndex = checkIn;
                        return chosenIndex;
                    }
                    chosenIndex = checkIn;
                }
            }
            return chosenIndex;
        }

        public override void PassBaggage(Baggage Lastbaggage)
        {
            throw new NotImplementedException();
        }
    }
}
