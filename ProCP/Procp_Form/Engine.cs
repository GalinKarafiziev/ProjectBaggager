using Procp_Form.Core;
using Procp_Form.CoreAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procp_Form
{
    public class Engine
    {
        private CheckIn checkIn;
        private DropOff dropOff;
        private List<CheckIn> checkIns;
        private List<DropOff> dropOffs;

        public Engine()
        {
            checkIns = new List<CheckIn>();
        }

        public List<CheckIn> CheckIns() => this.checkIns;
        public List<DropOff> DropOffs() => this.dropOffs;

        public void CreateCheckIn()
        {
            checkIn = new CheckIn();
            checkIns.Add(checkIn);
        }

        public void CreateDropOff()
        {
            dropOff = new DropOff();
            dropOffs.Add(dropOff);
        }
                
        public void LinkTwoNodes(Node firstNode, Node secondNode)
        {
            firstNode.NextNode = secondNode;
        }
    }
}
