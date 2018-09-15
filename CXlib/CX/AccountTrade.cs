using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXlib
{
    public class AccountTrade
    {
        [JsonProperty("TradeId")]
        public int TradeId { get; internal set; }
        [JsonProperty("OrderId")]
        public int OrderId { get; internal set; }
        [JsonProperty("AccountId")]
        public int AccountId { get; internal set; }
        [JsonProperty("ClientOrderId")]
        public int ClientOrderId { get; internal set; }
        [JsonProperty("InstrumentId")]
        public int InstrumentId { get; internal set; }
        [JsonProperty("Side")]
        public string Side { get; internal set; }
        [JsonProperty("Quantity")]
        public decimal Quantity { get; internal set; }
        [JsonProperty("Price")]
        public decimal Price { get; internal set; }
        [JsonProperty("Value")]
        public decimal Value { get; internal set; }
        [JsonProperty("TradeTime")]
        public long TradeTime { get; internal set; }
    }
}
