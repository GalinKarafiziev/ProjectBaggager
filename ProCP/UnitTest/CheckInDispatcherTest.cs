using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Procp_Form.Airport;
using Procp_Form.Core;

namespace UnitTest
{
    [TestClass]
    public class CheckInDispatcher
    {
        [TestMethod]
        public void CalculateDispatchRate_Test()
        {
           
            //var datetime = new DateTime(2018, 5, 2, 16, 00, 0);
            DateTime date = new DateTime(2019, 5,2,17, 05, 0 );
            Flight flight = new Flight(date, "BABY98", 3);
            Procp_Form.Core.CheckInDispatcher checkInDispatcher = new Procp_Form.Core.CheckInDispatcher();
            double a = checkInDispatcher.CalculateDispatchRate(flight);

            Assert.AreEqual(600000, a);

        }
    }
}
