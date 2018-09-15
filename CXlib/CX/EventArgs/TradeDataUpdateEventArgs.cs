using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXlib
{
    public class TradeDataUpdateEventArgs
    {
        public int SequenceNumber { get; internal set; }
        public MarketTrade[] Trades { get; internal set; }
    }
}
