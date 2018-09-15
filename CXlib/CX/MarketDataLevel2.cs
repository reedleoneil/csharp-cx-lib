using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXlib
{
    public class MarketDataLevel2
    {
        public int SequenceNumber { get; internal set; }
        public int NumTraders { get; internal set; }
        public long Timestamp { get; internal set; }
        public int ChangeType { get; internal set; }
        public decimal LastTradedPx { get; internal set; }
        public int NumOrders { get; internal set; }
        public decimal Price { get; internal set; }
        public int InstrumenId { get; internal set; }
        public decimal Quantity { get; internal set; }
        public int Side { get; internal set; }
    }
}
