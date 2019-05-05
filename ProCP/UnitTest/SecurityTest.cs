using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Procp_Form.Core;
using Procp_Form.CoreAbstraction;

namespace UnitTest
{
    [TestClass]
    public class SecurityTest
    {
        
        [TestMethod]
        public void ProcessBaggage_If_Statement()
        {
            Baggage baggage = new Baggage(){ Secure = 5 };
            Security security = new Security();
            CheckIn checkIn = new CheckIn();
            Conveyor conveyor = new Conveyor();
            DropOff dropOff = new DropOff(1);
            checkIn.NextNode = conveyor;
            conveyor.NextNode = security;
            security.NextNode = dropOff;

            security.PassBaggage(baggage);

            Assert.AreEqual(1, security.bufferNotSecure.Count);
        }
        [TestMethod]
        public void ProcessBaggage_If_Else_Statement()
        {
            Baggage baggage = new Baggage() { Secure = 6 };
            
            Security security = new Security();
            CheckIn checkIn = new CheckIn();
            Conveyor conveyor = new Conveyor();
            DropOff dropOff = new DropOff(1);
            checkIn.NextNode = conveyor;
            conveyor.NextNode = security;
            security.NextNode = dropOff;

            security.PassBaggage(baggage);

            Assert.AreEqual(BaggageStatus.Free , security.Status);
        }
        [TestMethod]
        public void ProcessBaggage_Else_Statement()
        {
            Baggage baggage = new Baggage() { Secure = 6 };
            Security security = new Security();
            CheckIn checkIn = new CheckIn();
            Conveyor conveyor = new Conveyor();
            DropOff dropOff = new DropOff(1);
            checkIn.NextNode = conveyor;
            conveyor.NextNode = security;
            security.NextNode = dropOff;
            int count = 0;
            dropOff.Status = BaggageStatus.Busy;
            security.PassBaggage(baggage);

            if (security.NextNode.OnNodeStatusChangedToFree != null)
            {
                count = security.NextNode.OnNodeStatusChangedToFree.GetInvocationList().Length;
            }

            Assert.AreEqual(1, count);


        }

        
    }
}
