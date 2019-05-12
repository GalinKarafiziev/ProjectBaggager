using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Procp_Form.Airport;
using Procp_Form.Core;
using Procp_Form.CoreAbstraction;

namespace UnitTest
{
    [TestClass]
    public class CheckInDispatcher
    {
        [TestMethod]
        public void CalculateDispatchRate_Test()
        {
            DateTime date = new DateTime(2019, 5,12,12, 01, 0 );
            Flight flight = new Flight(date, "BABY98", 3);
            Procp_Form.Core.CheckInDispatcher checkInDispatcher = new Procp_Form.Core.CheckInDispatcher();

            double a = checkInDispatcher.CalculateDispatchRate(flight);
            
            //works if and only if you set the date to half an hour after the current time,
            //so if for an example the time right now is 12, the date should be set to 12:30.
            Assert.AreEqual(600000, a);
        }

        [TestMethod]
        public void Start_Test()
        {
          
        }

        [TestMethod]
        public void DispatchBaggage_Test()
        {

        }

        [TestMethod]
        public void PassQueuedBaggage_Test()
        {
            CheckIn checkIn = new CheckIn();
            Conveyor conveyor = new Conveyor(){Status = BaggageStatus.Free};
            DropOff dropOff = new DropOff(){Status = BaggageStatus.Free};

            checkIn.NextNode = conveyor;
            conveyor.NextNode = dropOff;

            List<CheckIn> checkInList = new List<CheckIn>();
            checkInList.Add(checkIn);
            Procp_Form.Core.CheckInDispatcher checkInDispatcher = new Procp_Form.Core.CheckInDispatcher();
            int index = 0;
            checkInDispatcher.SetupCheckins(checkInList);
            checkInDispatcher.PassQueuedBaggage(index);
            int test = dropOff.GetBaggages().Count;
            Assert.AreEqual(test, 1);
        }

        [TestMethod]
        public void SetupCheckIns_SetupQueues_Test()
        {
            List<CheckIn> checkInList = new List<CheckIn>(){ new CheckIn(), new CheckIn(),};
            Procp_Form.Core.CheckInDispatcher checkInDispatcher = new Procp_Form.Core.CheckInDispatcher();

            checkInDispatcher.SetupCheckins(checkInList);

            //test if the check-ins are added correctly
            Assert.AreEqual(2, checkInDispatcher.GetCheckIns().Count);
            //test if the queued baggages are added correctly
            Assert.AreEqual(2, checkInDispatcher.GetQueuedBaggage().Count);
        }
        [TestMethod]
        public void FindMostSuitableCheckIn_WhenFreeCheckIn_Test()
        {
            CheckIn checkIn = new CheckIn();
            CheckIn checkIn2 = new CheckIn();

            checkIn.Status = BaggageStatus.Busy;
            checkIn2.Status = BaggageStatus.Free;

            Procp_Form.Core.CheckInDispatcher dispatcher = new Procp_Form.Core.CheckInDispatcher();
            
            List<CheckIn> checkIns = new List<CheckIn>();
            List<Queue<Baggage>> baggages = new List<Queue<Baggage>>()
            {
                new Queue<Baggage>(),
                new Queue<Baggage>(),
            };
            checkIns.Add(checkIn);
            checkIns.Add(checkIn2);

            dispatcher.SetupCheckins(checkIns);

            int a = dispatcher.FindMostSuitableCheckin();

            Assert.AreEqual(a, 1);

        }
        [TestMethod]
        public void FindMostSuitableCheckIn_WhenBusyCheckIn_Test()
        {
            CheckIn checkIn = new CheckIn();
            CheckIn checkIn2 = new CheckIn();

            checkIn.Status = BaggageStatus.Busy;
            checkIn2.Status = BaggageStatus.Busy;

            Procp_Form.Core.CheckInDispatcher dispatcher = new Procp_Form.Core.CheckInDispatcher();

            List<CheckIn> checkIns = new List<CheckIn>();
            List<Queue<Baggage>> baggages = new List<Queue<Baggage>>()
            {
                new Queue<Baggage>(),
                new Queue<Baggage>(),
            };
            checkIns.Add(checkIn);
            checkIns.Add(checkIn2);

            dispatcher.SetupCheckins(checkIns);

            int a = dispatcher.FindMostSuitableCheckin();

            Assert.AreEqual(a, 1);

        }

    }
}
