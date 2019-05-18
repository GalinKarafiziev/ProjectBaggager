using Procp_Form.Airport;
using Procp_Form.Core;
using Procp_Form.CoreAbstraction;
using Procp_Form.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procp_Form
{
    public class Engine
    {
        private StatisticsManager statistics;
        private MPA mainProcessArea;
        private Security security;
        public CheckInDispatcher dispatcher;
        public List<CheckIn> checkIns;
        public List<DropOff> dropOffs;
        public List<Conveyor> conveyors;
        public List<Flight> flights;
        private Flight flight;
        

        public Engine()
        {
            conveyors = new List<Conveyor>();
            checkIns = new List<CheckIn>();
            dropOffs = new List<DropOff>();
            flights = new List<Flight>();
            statistics = new StatisticsManager();
        }

        public void AddDispatcher()
        {
            dispatcher = new CheckInDispatcher();
        }

        public void AddCheckIn(CheckIn checkin) => checkIns.Add(checkin);

        public void AddDropOff(DropOff dropOff) => dropOffs.Add(dropOff);

        public void AddConveyorPart(Conveyor conveyor)
        {
            conveyors.Add(conveyor);
        }

        public void AddSecurity(Security security) => this.security = security;

        public void AddMPA(MPA mpa) => this.mainProcessArea = mpa;

        public bool AddFlight(DateTime time, string number, int baggage)
        {
            flight = new Flight(time, number, baggage);
            if (flights.Count == 0)
            {
                flights.Add(flight);
                return true;
            }
            else
            {
                foreach (Flight f in flights)
                {
                    if (this.flight.FlightNumber == f.FlightNumber)
                    {
                        return false;
                    }
                }
                flights.Add(flight);
            }
            return true;
        }

        public void LinkTwoNodes(Node firstNode, Node secondNode)
        {
            firstNode.NextNode = secondNode;
        }

        public void Run()
        {        
            foreach (var conveyor in conveyors)
            {
                conveyor.Start();
            }
            dispatcher.SetupCheckins(checkIns);
            dispatcher.SetupTimers(flights);
            dispatcher.Start();
        }

        public void Resume()
        {
            foreach (var conveyor in conveyors)
            {
                conveyor.Start();
            }
            dispatcher.Start();
        }

        public void Pause()
        {
            foreach (var conveyor in conveyors)
            {
                conveyor.Stop();
            }
            dispatcher.Stop();
        }

        public void Stop()
        {
            dispatcher.Stop();
            foreach (var conveyor in conveyors)
            {
                conveyor.Stop();
                for (int i = 0; i < conveyor.conveyorBelt.Length - 1; i++)
                {
                    if (conveyor.conveyorBelt[i] != null)
                    {
                        conveyor.conveyorBelt[i] = null;
                    }
                }
            }

            foreach (var dropOff in dropOffs)
            {
                dropOff.baggages.Clear();
                dropOff.Status = BaggageStatus.Free;
            }

            foreach (var checkin in checkIns)
            {
                checkin.baggage = null;
                checkin.Status = BaggageStatus.Free;
            }

            if (dispatcher == null)
            {
                return;
            }
            dispatcher = null;
        }

        public void Remove(Node rem)
        {
            if(rem is Conveyor)
            {
                conveyors.Remove((Conveyor)rem);
            }
            else if(rem is CheckIn)
            {
                checkIns.Remove((CheckIn)rem);
            }
            else if (rem is DropOff)
            {
                dropOffs.Remove((DropOff)rem);
            }
            rem = null;
        }

        public List<int> GetCheckInStats()
        {
            return null;
        }
    }
}
