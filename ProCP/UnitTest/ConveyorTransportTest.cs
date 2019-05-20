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
            Conveyor conveyor = new Conveyor(5,6);
            DropOff dropOff = new DropOff();
            conveyor.NextNode = dropOff;
            dropOff.Status = BaggageStatus.Busy;

            conveyor.CanMove();

            Assert.IsFalse(conveyor.CanMove());
        }
        [TestMethod]
        public void Move_If_Statement()
        {
            Baggage baggage = new Baggage();
            Conveyor conveyor = new Conveyor(5,6);
            DropOff dropOff = new DropOff();

            conveyor.NextNode = dropOff;
            dropOff.Status = BaggageStatus.Free;
            conveyor.PassBaggage(baggage);

            Assert.AreEqual(BaggageStatus.Busy, conveyor.Status );
            Assert.AreEqual(conveyor.conveyorBelt[0].Equals(baggage), conveyor.conveyorBelt[0].Equals(baggage));
        }
        
        
    }
}
