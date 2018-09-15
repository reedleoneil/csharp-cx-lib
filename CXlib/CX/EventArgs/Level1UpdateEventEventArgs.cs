using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXlib
{
    public class Level1UpdateEventArgs : EventArgs
    {
        public int SequenceNumber { get; internal set; }
        public MarketDataLevel1 MarketData { get; internal set; }
    }
}
