using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXlib
{
    public class Order
    {
        [JsonProperty("AccountId")]
        public int AccountId { get; set; }
        [JsonProperty("ClientOrderId")]
        public int ClientOrderId { get; set; }
        [JsonProperty("OMSId")]
        public int OMSId { get; set; }
        [JsonProperty("UseDisplayQuantity")]
        public bool UseDisplayQuantity { get; set; }
        [JsonProperty("Quantity")]
        public decimal Quantity { get; set; }
        [JsonProperty("DisplayQuantity")]
        public decimal DisplayQuantity { get; set; }
        [JsonProperty("LimitPrice")]
        public decimal LimitPrice { get; set; }
        [JsonProperty("OrderIdOCO")]
        public int OrderIdOCO { get; set; }
        [JsonProperty("OrderType")]
        public int OrderType { get; set; }
        [JsonProperty("PegPriceType")]
        public int PegPriceType { get; set; }
        [JsonProperty("InstrumentId")]
        public int InstrumentId { get; set; }
        [JsonProperty("TrailingAmount")]
        public decimal TrailingAmount { get; set; }
        [JsonProperty("LimitOffset")]
        public decimal LimitOffset { get; set; }
        [JsonProperty("Side")]
        public int Side { get; set; }
        [JsonProperty("StopPrice")]
        public decimal StopPrice { get; set; }
        [JsonProperty("TimeInForce")]
        public int TimeInForce { get; set; }
    }
}
