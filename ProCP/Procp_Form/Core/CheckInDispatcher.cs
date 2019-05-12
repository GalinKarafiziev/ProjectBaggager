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
    public class CheckInDispatcher : Node
    {
        List<Queue<Baggage>> checkinQueues;
        List<Timer> timers;
        List<CheckIn> checkins;

        public CheckInDispatcher()
        {
            checkins = new List<CheckIn>();
            checkinQueues = new List<Queue<Baggage>>();
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
            int chosen = FindMostSuitableCheckin();
            var checkIn = checkins[chosen];
            var queue = checkinQueues[chosen];

            baggage.FlightNumber = flight.FlightNumber;

            if (checkIn.Status == BaggageStatus.Free)
            {
                checkIn.PassBaggage(baggage);
            }
            else
            {
                checkIn.OnNodeStatusChangedToFree += () => PassQueuedBaggage(chosen);
            }
            queue.Enqueue(baggage);
            flight.BaggageDispatched++;
        }

        public void PassQueuedBaggage(int index)
        {
            var checkIn = checkins[index];
            var queue = checkinQueues[index];

            checkIn.PassBaggage(queue.Dequeue());
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
            Timer timer;

            foreach (Flight f in flights)
            {
                timer = new Timer();
                timers.Add(timer);
                timer.Interval = CalculateDispatchRate(f);
                
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

        public int FindMostSuitableCheckin()
        {
            int chosenIndex = 0;
            var initialQueue = checkinQueues[chosenIndex];

            foreach (var checkIn in Enumerable.Range(0, checkins.Count))
            {
                if (checkins.ElementAt(checkIn).Status == BaggageStatus.Free)
                {
                    chosenIndex = checkIn;

                    return chosenIndex;
                }
            }

            foreach (var queue in Enumerable.Range(0, checkinQueues.Count))
            {
               if (checkinQueues.ElementAt(queue).Count < initialQueue.Count)
                {
                    chosenIndex = queue;
                }
            }

            return chosenIndex;
        }

        public double CalculateDispatchRate(Flight flight)
        {
            var currentTime = DateTime.Now;
            var interval = new TimeSpan();
            interval = currentTime - flight.DepartureTime ;
            double dispatchRate = (interval.Minutes);
            dispatchRate = dispatchRate * -60000;
            dispatchRate = dispatchRate / flight.AmountOfBaggage;

            return dispatchRate;
        }

        public override void PassBaggage(Baggage Lastbaggage)
        {
            throw new NotImplementedException();
        }
    }
}
