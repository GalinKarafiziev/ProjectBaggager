using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Timers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Procp_Form.Core;

namespace UnitTest
{
    [TestClass]
    public class DropOffTest
    {
        [TestMethod]
        public void UnloadBaggageTest()
        {
            DropOff dropOff = new DropOff();
            List<Baggage> baggages = new List<Baggage>()
            {
                new Baggage(),
                new Baggage(),
                new Baggage(),
                new Baggage(),
                new Baggage(),
                new Baggage(),
                new Baggage(),
                new Baggage(),
                new Baggage(),
                new Baggage()
            };
            dropOff.SetNumberEmployees(1);
            dropOff.baggages = baggages;
            Thread.Sleep(1000);

            Assert.AreEqual(9, dropOff.baggages.Count);
            Assert.AreEqual(1, dropOff.unloadBaggages.Count);
        }
    }
}
