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
            Conveyor conveyor2 = new Conveyor(5, 6) { DestinationGate = 1 };
            Conveyor conveyor3 = new Conveyor(5, 6) { DestinationGate = 1 };
            mpa.AddNextNode(conveyor);
            mpa.AddNextNode(conveyor2);
            mpa.AddNextNode(conveyor3);
            Assert.AreEqual(3, mpa.nextNodes.Count);
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
            //Conveyor conveyornext = new Conveyor(5, 6) { DestinationGate = 2};
            conveyor.Status = BaggageStatus.Busy;
            Baggage baggage = new Baggage() { DestinationGate = 2 };
            var var = 0;
            mpa.AddNextNode(conveyor);
            //mpa.AddNextNode(conveyornext);
            mpa.PassBaggage(baggage);

            if (mpa.NextNode.OnNodeStatusChangedToFree != null)
            {
                var = mpa.NextNode.OnNodeStatusChangedToFree.GetInvocationList().Length;
            }
            Assert.AreEqual(var, 1);
            //Assert.AreEqual(mpa.baggagesToWait.Count, 1);
        }

        [TestMethod]
        public void PassBaggage_Test()
        {
            Baggage baggage = new Baggage();
            MPA mpa = new MPA();
            mpa.PassBaggage(baggage);
            Assert.AreEqual(baggage, mpa.baggage);
        }
       
       



        }
    }

