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
            
            Security security = new Security();
            CheckIn checkIn = new CheckIn();
            Conveyor conveyor = new Conveyor(5 ,4);
            DropOff dropOff = new DropOff();
            checkIn.NextNode = conveyor;
            conveyor.NextNode = security;
            security.NextNode = dropOff;

            List<Baggage> baggages = new List<Baggage>()
            {
                new Baggage(){Secure = 2},
                new Baggage(){Secure = 7},
               
            };
            
            foreach(Baggage baggage in baggages)
            {
                security.PassBaggage(baggage);
            }
            

            Assert.AreEqual(2, security.bufferNotSecure.Count);
        }
        [TestMethod]
        public void ProcessBaggage_If_Else_Statement()
        {
            Baggage baggage = new Baggage() { Secure = 6 };
            
            Security security = new Security();
            CheckIn checkIn = new CheckIn();
            Conveyor conveyor = new Conveyor(5,6);
            DropOff dropOff = new DropOff();
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
            Conveyor conveyor = new Conveyor(5,6);
            DropOff dropOff = new DropOff();
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
