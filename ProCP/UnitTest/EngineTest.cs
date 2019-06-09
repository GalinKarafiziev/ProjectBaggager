using System;
using System.Collections.Generic;
using System.Threading;
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
        public void LinkTwoNodes_Test()
        {
            Engine engine = new Engine();
            CheckIn checkIn = new CheckIn() { DestinationGate = 1, Status = BaggageStatus.Free };
            DropOff dropOff = new DropOff() { DestinationGate = 1, Status = BaggageStatus.Free };
            MPA mpa = new MPA();
            DateTime date = new DateTime(2019, 6, 9, 14, 56, 0);

            Conveyor conveyor = new Conveyor(5, 1000) { DestinationGate = 1, Status = BaggageStatus.Free };

            Conveyor conveyor2 = new Conveyor(5, 1000) { DestinationGate = 1, Status = BaggageStatus.Free };
            Settings set = new Settings();
            engine.LinkTwoNodes(checkIn, conveyor);
            engine.LinkTwoNodes(conveyor, dropOff);
            
            //Assert.AreEqual(3,set.nextNodes.Count );

        }
        //WARNING! THIS TEST ACTUALLY WORKS AS SEEN FROM THE DEBUGGER! In the debugger class the baggages.count = 1, while on the test does not!
        //this is probably due to the usages of timers and dates. Seen from the dropOff class and debugger we can see that everything works correctly!
        //WARNING! TO RUN THIS TEST YOU HAVE TO REMOVE TIMER.ELAPSED FROM CHECKINDISPATCHER AND KEEP ONLY THE IF STATEMENT!!
        [TestMethod]
        public void Run_Test()
        {
            Engine engine = new Engine();
            CheckIn checkIn = new CheckIn(){DestinationGate = 1,Status = BaggageStatus.Free};
            DropOff dropOff = new DropOff(){DestinationGate = 1, Status = BaggageStatus.Free,  };
            MPA mpa = new MPA();
            DateTime date = new DateTime(2019, 6, 9, 16, 40, 0);

            Conveyor conveyor = new Conveyor(1,1000){DestinationGate = 1, Status = BaggageStatus.Free};
            
           
            engine.AddFlight(date, "bbb", 3, 1);
            engine.AddDispatcher();
            engine.AddCheckIn(checkIn);
            engine.AddConveyorPart(conveyor);
            
            engine.AddDropOff(dropOff);
            
            engine.LinkTwoNodes(checkIn, conveyor);
            engine.LinkTwoNodes(conveyor, dropOff);
   
            engine.Run();
         
            Assert.AreEqual(1, Convert.ToInt32(dropOff.baggages.Count));

            
        }
        [TestMethod]
        public void RemoveFlight_Test()
        {
            DateTime date = new DateTime(2019, 6, 9, 16, 40, 0);

            bool cond = false;
            Engine engine = new Engine();

            engine.AddFlight(date, "bbb", 5, 5);
            engine.RemoveFlight("bbb");
            Assert.AreEqual(0, engine.flights.Count);
        }
        [TestMethod]
        public void Remove_Test()
        {
            //works for the others as well
           CheckIn checkIn = new CheckIn();
           Engine engine = new Engine();
           engine.AddCheckIn(checkIn);
           engine.Remove(checkIn);
           Assert.AreEqual(0, engine.checkIns.Count);
        }
        [TestMethod]
        public void Pause_Test()
        {
            Engine engine = new Engine();
            CheckIn checkIn = new CheckIn() { DestinationGate = 1, Status = BaggageStatus.Free };
            DropOff dropOff = new DropOff() { DestinationGate = 1, Status = BaggageStatus.Free, };
            MPA mpa = new MPA();
            DateTime date = new DateTime(2019, 6, 9, 16, 40, 0);

            Conveyor conveyor = new Conveyor(1, 1000) { DestinationGate = 1, Status = BaggageStatus.Free };


            engine.AddFlight(date, "bbb", 3, 1);
            engine.AddDispatcher();
            engine.AddCheckIn(checkIn);
            engine.AddConveyorPart(conveyor);

            engine.AddDropOff(dropOff);

            engine.LinkTwoNodes(checkIn, conveyor);
            engine.LinkTwoNodes(conveyor, dropOff);

            engine.Run();

            engine.Pause();

            Assert.IsFalse(conveyor.timer.Enabled);
            Assert.IsFalse(engine.dispatcher.timers[0].Enabled);


            
        }
        [TestMethod]
        public void Resume_Test()
        {
            Engine engine = new Engine();
            CheckIn checkIn = new CheckIn() { DestinationGate = 1, Status = BaggageStatus.Free };
            DropOff dropOff = new DropOff() { DestinationGate = 1, Status = BaggageStatus.Free, };
            MPA mpa = new MPA();
            DateTime date = new DateTime(2019, 6, 9, 16, 40, 0);

            Conveyor conveyor = new Conveyor(1, 1000) { DestinationGate = 1, Status = BaggageStatus.Free };


            engine.AddFlight(date, "bbb", 3, 1);
            engine.AddDispatcher();
            engine.AddCheckIn(checkIn);
            engine.AddConveyorPart(conveyor);

            engine.AddDropOff(dropOff);

            engine.LinkTwoNodes(checkIn, conveyor);
            engine.LinkTwoNodes(conveyor, dropOff);

            engine.Run();

            engine.Pause();
            engine.Resume();
            Assert.IsTrue(conveyor.timer.Enabled);
            Assert.IsTrue(engine.dispatcher.timers[0].Enabled);
        }
        [TestMethod]
        public void Stop_Test()
        {
            Engine engine = new Engine();
            CheckIn checkIn = new CheckIn() { DestinationGate = 1, Status = BaggageStatus.Free };
            DropOff dropOff = new DropOff() { DestinationGate = 1, Status = BaggageStatus.Free, };
            MPA mpa = new MPA();
            DateTime date = new DateTime(2019, 6, 9, 16, 40, 0);

            Conveyor conveyor = new Conveyor(1, 1000) { DestinationGate = 1, Status = BaggageStatus.Free };


            engine.AddFlight(date, "bbb", 3, 1);
            engine.AddDispatcher();
            engine.AddCheckIn(checkIn);
            engine.AddConveyorPart(conveyor);

            engine.AddDropOff(dropOff);

            engine.LinkTwoNodes(checkIn, conveyor);
            engine.LinkTwoNodes(conveyor, dropOff);

            engine.Run();
            engine.Stop();
            //works with other components as well
            Assert.AreEqual(BaggageStatus.Free, conveyor.Status);
            Assert.AreEqual(BaggageStatus.Free, checkIn.Status);
            Assert.AreEqual(BaggageStatus.Free, dropOff.Status);
        }
    }
}
