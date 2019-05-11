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
        }

        public void AddCheckIn(CheckIn checkin) => checkIns.Add(checkin);

        public void AddDropOff(DropOff dropOff) =>  dropOffs.Add(dropOff);

        public void AddConveyorPart(Conveyor conveyor) => conveyors.Add(conveyor);

        public void AddCheckInDispatcher(CheckInDispatcher dispatcher) => this.dispatcher = dispatcher;

        public void AddSecurity(Security security) => this.security = security;

        public void AddMPA(MPA mpa) => this.mainProcessArea = mpa;

        public void AddFlight(DateTime time, string number, int baggage)
        {
            flight = new Flight(time, number, baggage);
            flights.Add(flight);
        }

        public void LinkTwoNodes(Node firstNode, Node secondNode)
        {
            firstNode.NextNode = secondNode;
        }

        public void Run()
        {
            //this.flights.ForEach(f => dispatcher.DispatchBaggage(f));

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
