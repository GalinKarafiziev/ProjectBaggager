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
            Conveyor conveyor = new Conveyor(5,6){DestinationGate = 1};
            mpa.AddNextNode(conveyor);
            Assert.AreEqual(1, mpa.nextNodes.Count);
        }
         
        [TestMethod]
        public void ProcessBaggage_If_Statement()
        {
            
            DropOff drop = new DropOff(){DestinationGate = 1};
            Baggage baggage = new Baggage(){DestinationGate = 1};
            List<Baggage> baggages = new List<Baggage>()
            {
                baggage,
            };
            drop.baggages = baggages;
            MPA mpa = new MPA();
            Conveyor conveyor = new Conveyor(5, 6){DestinationGate = 1};
            mpa.AddNextNode(conveyor);
            mpa.PassBaggage(baggage);
            
            Assert.AreEqual(null, mpa.baggage);
            Assert.AreEqual(BaggageStatus.Free, mpa.Status);
        }
    }
}
