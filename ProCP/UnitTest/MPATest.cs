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
            DropOff drop = new DropOff(1);
            MPA mpa = new MPA();
            mpa.AddNextNode(drop);
            Assert.AreEqual(1, mpa.nextNodes.Count);
        }
         
        [TestMethod]
        public void ProcessBaggage_If_Statement()
        {
            
            DropOff drop = new DropOff(1);
            Baggage baggage = new Baggage(){DestinationGateId = 1};
            List<Baggage> baggages = new List<Baggage>()
            {
                baggage,
            };
            drop.baggages = baggages;
            MPA mpa = new MPA();
            List<DropOff> dropoffs = new List<DropOff>()
            {
                drop,
            };
            mpa.nextNodes = dropoffs;

            mpa.PassBaggage(baggage);

            Assert.AreEqual(null, mpa.baggage);
            Assert.AreEqual(BaggageStatus.Free, mpa.Status);
        }
    }
}
