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
        private List<CheckIn> checkIns;
        private List<DropOff> dropOffs;
        private List<Conveyor> conveyors;

        public Engine()
        {
            conveyors = new List<Conveyor>();
            checkIns = new List<CheckIn>();
            dropOffs = new List<DropOff>();
        }

        //public List<CheckIn> CheckIns() => this.checkIns;
        //public List<DropOff> DropOffs() => this.dropOffs;

        public void AddCheckIn(CheckIn checkin)
        {
            checkIns.Add(checkin);
        }

        public void AddDropOff(DropOff dropOff)
        {
            dropOffs.Add(dropOff);
        }

        public void AddConveyorPart(Conveyor conveyor)
        {
            conveyors.Add(conveyor);
        }

        public void AddCheckInDispatcher(CheckInDispatcher dispatcher) => this.dispatcher = dispatcher;

        public void AddSecurity(Security security) => this.security = security;

        public void AddMPA(MPA mpa) => this.mainProcessArea = mpa;

        public void AddFlight(DateTime time, string number, int baggage)
        {

        }

        public void LinkTwoNodes(Node firstNode, Node secondNode)
        {
            firstNode.NextNode = secondNode;
        }

    }
}
