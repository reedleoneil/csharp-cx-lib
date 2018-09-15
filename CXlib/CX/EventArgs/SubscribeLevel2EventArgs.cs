using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXlib
{
    public class SubscribeLevel2EventArgs : EventArgs
    {
        public int SequenceNumber { get; internal set; }
        public MarketDataLevel2[] MarketData { get; internal set; }
    }
}
