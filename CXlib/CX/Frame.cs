using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXlib
{
    class Frame
    {
        public int MessageType { get; }
        public int SequenceNumber { get; }
        public string FunctionName { get; }
        public string Payload { get; }
        public Frame(int m, int i, string n, string o)
        {
            this.MessageType = m;
            this.SequenceNumber = i;
            this.FunctionName = n;
            this.Payload = o;
        }
    }
}
