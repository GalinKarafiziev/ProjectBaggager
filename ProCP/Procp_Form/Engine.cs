using Procp_Form.Airport;
using Procp_Form.Core;
using Procp_Form.CoreAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procp_Form
{
    public class Engine
    {
        private MPA mainProcessArea;
        private Security security;
        private CheckInDispatcher dispatcher;
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
            dispatcher = new CheckInDispatcher();
        }

        public void AddCheckIn(CheckIn checkin) => checkIns.Add(checkin);

        public void AddDropOff(DropOff dropOff) => dropOffs.Add(dropOff);

        public void AddConveyorPart(Conveyor conveyor) => conveyors.Add(conveyor);

        public void AddSecurity(Security security) => this.security = security;

        public void AddMPA(MPA mpa) => this.mainProcessArea = mpa;

        public bool AddFlight(DateTime time, string number, int baggage)
        {
            flight = new Flight(time, number, baggage);
            if (flights.Count == 0)
            {
                flights.Add(flight);
            }
            foreach (Flight f in flights)
            {
                if (this.flight.FlightNumber == f.FlightNumber)
                {
                    return false;
                }
            }
            flights.Add(flight);
            return true;
        }

        public void LinkTwoNodes(Node firstNode, Node secondNode)
        {
            firstNode.NextNode = secondNode;
        }

        public void Run()
        {
            dispatcher.SetupCheckins(checkIns);
            dispatcher.SetupTimers(flights);
            dispatcher.Start();
        }

        public void Stop()
        {
            dispatcher.Stop();
        }
    }
}
