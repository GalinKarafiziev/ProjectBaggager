using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Procp_Form.Core;
using Procp_Form.CoreAbstraction;

namespace UnitTest
{
    [TestClass]
    public class ConveyorTest
    {
        [TestMethod]
        public void CanMove_Test()
        {
            Baggage baggage = new Baggage();
            Conveyor conveyor = new Conveyor();
            DropOff dropOff = new DropOff(1);
            conveyor.NextNode = dropOff;
            dropOff.Status = BaggageStatus.Busy;

            conveyor.CanMove();

            Assert.IsFalse(conveyor.CanMove());
        }
        [TestMethod]
        public void Move_If_Statement()
        {
            Baggage baggage = new Baggage();
            Conveyor conveyor = new Conveyor();
            DropOff dropOff = new DropOff(1);

            conveyor.NextNode = dropOff;
            dropOff.Status = BaggageStatus.Free;
            conveyor.PassBaggage(baggage);

            Assert.AreEqual(BaggageStatus.Free, conveyor.Status);
        }

        [TestMethod]
        public void Move_Else_Statement()
        {
            Baggage baggage = new Baggage();
            Conveyor conveyor = new Conveyor();
            DropOff dropOff = new DropOff(1);
            int counter = 0;
            conveyor.NextNode = dropOff;
            dropOff.Status = BaggageStatus.Busy;
            conveyor.PassBaggage(baggage);
            if (dropOff.OnNodeStatusChangedToFree != null)
            {
                counter = dropOff.OnNodeStatusChangedToFree.GetInvocationList().Length;
            }
            Assert.AreEqual(1, counter);
        }
    }
}
