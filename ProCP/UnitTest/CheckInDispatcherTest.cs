using System;
using System.Collections;
using System.Collections.Generic;
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
            DateTime date = new DateTime(2019, 5,2,20, 18, 0 );
            Flight flight = new Flight(date, "BABY98", 3);
            Procp_Form.Core.CheckInDispatcher checkInDispatcher = new Procp_Form.Core.CheckInDispatcher();
            double a = checkInDispatcher.CalculateDispatchRate(flight);

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
        public void FindMostSuitableCheckIn_Test()
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
            dispatcher.SetupCheckins(checkIns);
            checkIns.Add(checkIn);
            checkIns.Add(checkIn2);


        }

    }
}
