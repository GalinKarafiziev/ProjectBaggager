using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Procp_Form.Core;
using Procp_Form.CoreAbstraction;

namespace UnitTest
{
    [TestClass]
    public class MPATest
    {
        [TestMethod]
        public void AddNextNode_Test()
        {
            DropOff drop = new DropOff();
            MPA mpa = new MPA();
            mpa.AddNextNode(drop);
            Assert.AreEqual(1, mpa.nextNodes.Count);
        }
         
        [TestMethod]
        public void ProcessBaggage_If_Statement()
        {
            
            DropOff drop = new DropOff(){FlightNumber = "RA3625"};
            Baggage baggage = new Baggage(){FlightNumber = "RA3625"};
            List<Baggage> baggages = new List<Baggage>()
            {
                baggage,
            };
            drop.baggages = baggages;
            MPA mpa = new MPA();
            
            mpa.AddNextNode(drop);
            mpa.PassBaggage(baggage);
            
            Assert.AreEqual(null, mpa.baggage);
            Assert.AreEqual(BaggageStatus.Free, mpa.Status);
        }
    }
}
