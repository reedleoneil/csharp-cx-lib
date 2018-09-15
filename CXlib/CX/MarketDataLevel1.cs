using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXlib
{
    public class MarketDataLevel1
    {
        [JsonProperty("InstrumentId")]
        public int InstrumentId { get; internal set; }
        [JsonProperty("BestBid")]
        public decimal BestBid { get; internal set; }
        [JsonProperty("BestOffer")]
        public decimal BestOffer { get; internal set; }
        [JsonProperty("LastTradedPx")]
        public decimal LastTradedPx { get; internal set; }
        [JsonProperty("LastTradedQty")]
        public decimal LastTradedQty { get; internal set; }
        [JsonProperty("LastTradeTime")]
        public long LastTradeTime { get; internal set; }
        [JsonProperty("SessionOpen")]
        public decimal SessionOpen { get; internal set; }
        [JsonProperty("SessionHigh")]
        public decimal SessionHigh { get; internal set; }
        [JsonProperty("SessionLow")]
        public decimal SessionLow { get; internal set; }
        [JsonProperty("SessionClose")]
        public decimal SessionClose { get; internal set; }
        [JsonProperty("Volume")]
        public decimal Volume { get; internal set; }
        [JsonProperty("CurrentDayVolume")]
        public decimal CurrentDayVolume { get; internal set; }
        [JsonProperty("CurrentDayNumTrades")]
        public int CurrentDayNumTrades { get; internal set; }
        [JsonProperty("CurrentDayPxChange")]
        public decimal CurrentDayPxChange { get; internal set; }
        [JsonProperty("Rolling24HrVolume")]
        public decimal Rolling24HrVolume { get; internal set; }
        [JsonProperty("Rolling24HrNumTrades")]
        public int Rolling24HrNumTrades { get; internal set; }
        [JsonProperty("Rolling24PxChange")]
        public decimal Rolling24PxChange { get; internal set; }
        [JsonProperty("TimeStamp")]
        public long TimeStamp { get; internal set; }
    }
}
