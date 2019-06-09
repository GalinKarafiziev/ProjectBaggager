using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Procp_Form.Core;
using Procp_Form.CoreAbstraction;

namespace UnitTest
{
    [TestClass]
    public class CheckInTest
    {
        [TestMethod]
        public void ProcessBaggage_If_Statement()
        { 
            CheckIn checkIn = new CheckIn();
            Conveyor conveyor = new Conveyor(2,5);
            DropOff dropOff = new DropOff();
            int var = 0;
            checkIn.NextNode = conveyor;
            conveyor.NextNode = dropOff;
            checkIn.Status = BaggageStatus.Busy;
            checkIn.ProcessBaggage();
            if (checkIn.NextNode.OnNodeStatusChangedToFree != null)
            {
                var = checkIn.NextNode.OnNodeStatusChangedToFree.GetInvocationList().Length;
            }
            Assert.AreEqual(BaggageStatus.Free, checkIn.Status);
            Assert.AreEqual(checkIn.baggageInCheckIn, 0);
            Assert.AreEqual(var, 0);
        }
        [TestMethod]
        public void ProcessBaggage_Else_Statement()
        {
            CheckIn checkIn = new CheckIn();
            Conveyor conveyor = new Conveyor(2,5);
            DropOff dropOff = new DropOff();
            int var = 0;
            checkIn.NextNode = conveyor;
            conveyor.NextNode = dropOff;
            checkIn.NextNode.Status = BaggageStatus.Busy;
            checkIn.ProcessBaggage();
            if (checkIn.NextNode.OnNodeStatusChangedToFree != null)
            {
                var = checkIn.NextNode.OnNodeStatusChangedToFree.GetInvocationList().Length;
            }
            Assert.AreEqual(1, var);
        }
        [TestMethod]
        public void PassBaggage_Test()
        {
            Baggage baggage = new Baggage();
            CheckIn checkIn = new CheckIn();
            Conveyor conveyor = new Conveyor(2,5);
            DropOff dropOff = new DropOff();
            
            checkIn.NextNode = conveyor;
            conveyor.NextNode = dropOff;

            checkIn.PassBaggage(baggage);

            Assert.AreEqual(BaggageStatus.Free, checkIn.Status);
            Assert.AreEqual(checkIn.baggageInCheckIn, 1);
        }
    }
}
