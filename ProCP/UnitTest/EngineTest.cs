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
        [TestMethod]
        public void Run_Test()
        {
            Engine engine = new Engine();
            CheckIn checkIn = new CheckIn(){Status = BaggageStatus.Free};
            DropOff dropOff = new DropOff(){FlightNumber = "BBB", Status = BaggageStatus.Free };
            MPA mpa = new MPA();
            DateTime date = new DateTime(2019, 5, 14, 21, 27, 0);
            Conveyor conveyor = new Conveyor(5,5){Status = BaggageStatus.Free};
            Flight flight = new Flight(date, "BBB", 5);
            CheckInDispatcher checkInDispatcher = new CheckInDispatcher();
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
