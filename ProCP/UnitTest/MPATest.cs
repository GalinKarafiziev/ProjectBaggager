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
        public void ProcessBaggageTest_IfStatement()
        {
            MPA mpa = new MPA();
            Conveyor conveyor = new Conveyor(5, 6) { DestinationGate = 2 };
            Conveyor conveyornext = new Conveyor(5, 6) { DestinationGate = 1 };
            Baggage baggage = new Baggage() { DestinationGate = 1 };
            
            mpa.AddNextNode(conveyor);
            mpa.AddNextNode(conveyornext);
            mpa.PassBaggage(baggage);

            Assert.AreEqual(mpa.NextNode, mpa.nextNodes[1]);
            Assert.AreEqual(BaggageStatus.Free, mpa.Status);
            Assert.AreEqual(null, mpa.baggage);
        }

        [TestMethod]
        public void ProcessBaggageTest_IfStatementElse()
        {
            MPA mpa = new MPA();
            Conveyor conveyor = new Conveyor(5, 6) { DestinationGate = 2 };
            Conveyor conveyornext = new Conveyor(5, 6) { DestinationGate = 1};
            conveyornext.Status = BaggageStatus.Busy;
            Baggage baggage = new Baggage() { DestinationGate = 1 };
            var var = 0;
            mpa.AddNextNode(conveyor);
            mpa.AddNextNode(conveyornext);
            mpa.PassBaggage(baggage);

            if (mpa.NextNode.OnNodeStatusChangedToFree != null)
            {
                var = mpa.NextNode.OnNodeStatusChangedToFree.GetInvocationList().Length;
            }
            Assert.AreEqual(var, 1);
            Assert.AreEqual(mpa.baggagesToWait.Count, 1);
        }

        [TestMethod]
        public void PassWaitingBaggageTest()
        {
            List<Baggage> baggages = new List<Baggage>()
            {
                new Baggage(){DestinationGate = 1},
                new Baggage(){DestinationGate = 2},
            };

            List<Conveyor> conveyors = new List<Conveyor>()
            {
                new Conveyor(5,6){DestinationGate = 1}
            };

            MPA mpa = new MPA();
            mpa.baggagesToWait = baggages;
            mpa.nextNodes = conveyors;

            mpa.PassWaitingBaggage(conveyors[0]);

            Assert.AreEqual(BaggageStatus.Free, mpa.Status);
            Assert.AreEqual(1, mpa.baggagesToWait.Count);



        }
    }
}
