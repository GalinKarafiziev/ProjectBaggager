using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Procp_Form.Airport;
using Procp_Form.Core;
using Procp_Form.CoreAbstraction;
using Timer = System.Timers.Timer;

namespace UnitTest
{
    [TestClass]
    public class CheckInDispatcher
    {
        //[TestMethod]
        public void CalculateDispatchRate_Test()
        {
            DateTime date = new DateTime(2019, 5,14,20, 44, 0 );
            Flight flight = new Flight(date, "BABY98", 3);
            Procp_Form.Core.CheckInDispatcher checkInDispatcher = new Procp_Form.Core.CheckInDispatcher();

            double a = checkInDispatcher.CalculateDispatchRate(flight);
            
            //works if and only if you set the date to half an hour after the current time,
            //so if for an example the time right now is 12, the date should be set to 12:30.
            Assert.AreEqual(600000, a);
        }
        //WARNING! IN ORDER FOR THIS TEST TO WORK YOU SHOULD CHANGE THE DATE TO MORE THAN THE CURRENT TIME
        //[TestMethod]
        public void SetupTimersIfStatement_Test()
        {
          DateTime date = new DateTime(2019, 5, 19, 20, 20, 0);
          Flight flight = new Flight(date, "BABY98", 3);
          flight.BaggageDispatched = 1;

          List<Flight> flights = new List<Flight>();
          flights.Add(flight);

          Procp_Form.Core.CheckInDispatcher checkInDispatcher = new Procp_Form.Core.CheckInDispatcher();
          checkInDispatcher.SetupTimers(flights);

          Assert.AreEqual(1, checkInDispatcher.timers.Count);
          Assert.AreEqual(1, flight.BaggageDispatched);
        }
        //SAME RULES APPLY HERE AS WELL!!
        //[TestMethod]
        public void SetupTimersElseStatement_Test()
        {
            DateTime date = new DateTime(2019, 5, 19, 20, 50, 0);
            Flight flight = new Flight(date, "BABY98", 3);
            flight.BaggageDispatched = 4;

            List<Flight> flights = new List<Flight>();
            flights.Add(flight);

            Procp_Form.Core.CheckInDispatcher checkInDispatcher = new Procp_Form.Core.CheckInDispatcher();
            checkInDispatcher.SetupTimers(flights);
            bool isStopped = false;
            
            foreach (Timer t in checkInDispatcher.timers)
            {
                if (t.Enabled == false)
                {
                    isStopped = true;
                }
            }

            Assert.IsTrue(isStopped);

        }
        [TestMethod]
        public void DispatchBaggageIfStatement_Test()
        {
            CheckIn checkIn = new CheckIn();
            DropOff dropOff = new DropOff() { Status = BaggageStatus.Free };
            checkIn.NextNode = dropOff;
            Procp_Form.Core.CheckInDispatcher checkInDispatcher = new Procp_Form.Core.CheckInDispatcher();
            Flight flight = new Flight(DateTime.Now, "GGG", 0);

            Queue<Baggage> baggageQueue = new Queue<Baggage>();
            Baggage baggage = new Baggage();
            Baggage baggage2 = new Baggage();
            baggageQueue.Enqueue(baggage);
            baggageQueue.Enqueue(baggage2);
            checkInDispatcher.checkins.Add(checkIn);
            checkInDispatcher.checkinQueues.Add(baggageQueue);

            checkInDispatcher.DispatchBaggage(flight);

            Assert.AreEqual(1, flight.BaggageDispatched);

        }
        [TestMethod]
        public void DispatchBaggageElseStatement_Test()
        {
            CheckIn checkIn = new CheckIn(){Status = BaggageStatus.Busy};
            DropOff dropOff = new DropOff() { Status = BaggageStatus.Free };
            checkIn.NextNode = dropOff;
            Procp_Form.Core.CheckInDispatcher checkInDispatcher = new Procp_Form.Core.CheckInDispatcher();
            Flight flight = new Flight(DateTime.Now, "GGG", 0);

            Queue<Baggage> baggageQueue = new Queue<Baggage>();
            Baggage baggage = new Baggage();
            Baggage baggage2 = new Baggage();
            baggageQueue.Enqueue(baggage);
            baggageQueue.Enqueue(baggage2);
            checkInDispatcher.checkins.Add(checkIn);
            checkInDispatcher.checkinQueues.Add(baggageQueue);

            checkInDispatcher.DispatchBaggage(flight);

            Assert.AreEqual(1, checkIn.OnNodeStatusChangedToFree.GetInvocationList().Length);
        }
        [TestMethod]
        public void PassQueuedBaggage_Test()
        {
            CheckIn checkIn = new CheckIn();
            DropOff dropOff = new DropOff(){Status = BaggageStatus.Free };
            checkIn.NextNode = dropOff;
            Procp_Form.Core.CheckInDispatcher checkInDispatcher = new Procp_Form.Core.CheckInDispatcher();
            Flight flight = new Flight(DateTime.Now, "GGG", 1);

            Queue<Baggage> baggageQueue = new Queue<Baggage>();
            Baggage baggage = new Baggage();
            Baggage baggage2 = new Baggage();
            baggageQueue.Enqueue(baggage);
            baggageQueue.Enqueue(baggage2);
            checkInDispatcher.checkins.Add(checkIn);
            checkInDispatcher.checkinQueues.Add(baggageQueue);
            
            checkInDispatcher.PassQueuedBaggage(0);
            Assert.AreEqual(1, dropOff.baggages.Count);
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
            Baggage baggage =  new Baggage();
            Queue<Baggage> baggagesQueue = new Queue<Baggage>();
            Queue<Baggage> baggagesQueue_True = new Queue<Baggage>();
            
            List<Queue<Baggage>> baggagesQueueList = new List<Queue<Baggage>>();
            
            checkIn.Status = BaggageStatus.Busy;
            checkIn2.Status = BaggageStatus.Busy;

            Procp_Form.Core.CheckInDispatcher dispatcher = new Procp_Form.Core.CheckInDispatcher();

            List<CheckIn> checkIns = new List<CheckIn>();
           
            checkIns.Add(checkIn);
            checkIns.Add(checkIn2);

            baggagesQueue.Enqueue(new Baggage());
            baggagesQueue.Enqueue(new Baggage());
            baggagesQueue_True.Enqueue(new Baggage());

            dispatcher.checkinQueues.Add(baggagesQueue);
            dispatcher.checkinQueues.Add(baggagesQueue_True);
            dispatcher.checkins = checkIns;
            
            int a = dispatcher.FindMostSuitableCheckin();

            Assert.AreEqual(a, 1);

        }

    }
}
