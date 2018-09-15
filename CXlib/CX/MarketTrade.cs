using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXlib
{
    public class MarketTrade
    {
        public int TradeId { get; internal set; }
        public int InstrumentId { get; internal set; }
        public decimal Quantity { get; internal set; }
        public decimal Price { get; internal set; }
        public long Timestamp { get; internal set; }
        public int Direction { get; internal set; }
        public int TakerSide { get; internal set; }
    }
}
