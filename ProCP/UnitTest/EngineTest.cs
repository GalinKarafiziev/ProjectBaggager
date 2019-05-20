using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Procp_Form;
using Procp_Form.Airport;
using Procp_Form.Core;
using Procp_Form.CoreAbstraction;

namespace UnitTest
{
    [TestClass]
    public class EngineTest
    {
        //WARNING! TO RUN THIS TEST YOU HAVE TO REMOVE TIMER.ELAPSED FROM CHECKINDISPATCHER AND KEEP ONLY THE IF STATEMENT!!
        //[TestMethod]
        public void Run_Test()
        {
            Engine engine = new Engine();
            CheckIn checkIn = new CheckIn(){Status = BaggageStatus.Free};
            DropOff dropOff = new DropOff(){DestinationGate = 1, Status = BaggageStatus.Free };
            MPA mpa = new MPA();
            DateTime date = new DateTime(2019, 5, 19, 14, 10, 0);
            Conveyor conveyor = new Conveyor(5,1000){DestinationGate = 1, Status = BaggageStatus.Free};
            Flight flight = new Flight(date, "BBB", 5){DestinationGate = 1};
            CheckInDispatcher checkInDispatcher = new CheckInDispatcher();
            engine.AddDispatcher();
            engine.AddCheckIn(checkIn);
            engine.conveyors.Add(conveyor);
            engine.AddDropOff(dropOff);
            engine.flights.Add(flight);
            engine.LinkTwoNodes(checkIn, conveyor);
            engine.LinkTwoNodes(conveyor, dropOff);
            engine.Run();

            Assert.AreEqual(1, dropOff.baggages.Count);
        }
    }
}
