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

        public CheckInDispatcher(int amountOfBaggage)
        {
            checkins = new List<CheckIn>();
            checkinQueues = new List<Queue<Baggage>>();
        }

        public void Start()
        {
            foreach (Timer t in timers)
            {
                t.Enabled = true;
                t.Start();
            }
        }

        public void Stop()
        {
            foreach (Timer t in timers)
            {
                t.Enabled = false;
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
                checkIn.OnNodeStatusChangedToFree += () => { PassQueuedBaggage(chosen); };
            }
            queue.Enqueue(baggage);
        }
        public void PassQueuedBaggage(int index)
        {
            var checkIn = checkins[index];
            var queue = checkinQueues[index];
        }
        public void SetCheckins(List<CheckIn> checkinDesks)
        {
            foreach (CheckIn desk in checkins)
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
            Timer timer;
            foreach (Flight f in flights)
            {
                timer = new Timer();
                timers.Add(timer);
                timer.Interval = CalculateDispatchRate(f);
                timer.Elapsed += (sender, args) =>
                {
                    if (NextNode.Status == BaggageStatus.Free)
                    {

                    }
                };
            }
        }

        public int FindMostSuitableCheckin()
        {
            return 0;
        }

        public int CalculateDispatchRate(Flight flight)
        {
            var currentTime = DateTime.Now;
            var interval = new TimeSpan();
            interval = currentTime - flight.DepartureTime;
            int dispatchRate = (interval.Seconds) * 1000;

            return dispatchRate;
        }

        public override void PassBaggage(Baggage Lastbaggage)
        {
            throw new NotImplementedException();
        }
    }
}
