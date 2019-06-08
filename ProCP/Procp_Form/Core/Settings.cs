using Procp_Form.CoreAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procp_Form.Core
{
    [Serializable]
    public class Settings
    {
        public int conveyorCount { get; set; }
        public int dropOffCount { get; set; }

        public List<int> DestGates;
        public List<int> ConveyorsLength;
        public List<int> ConveyorsSpeed;
        public List<Node> nextNodes;


        public Settings()
        {
            ConveyorsLength = new List<int>();
            ConveyorsSpeed = new List<int>();
            DestGates = new List<int>();
            nextNodes = new List<Node>();
        }
    }
}
