using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXlib
{
    public class OrderStatus
    {
        [JsonProperty("Account")]
        public int Account { get; internal set; }
        [JsonProperty("ClientOrderId")]
        public int ClientOrderId { get; internal set; }
        [JsonProperty("Quantity")]
        public decimal Quantity { get; internal set; }
        [JsonProperty("OrderType")]
        public int OrderType { get; internal set; }
        [JsonProperty("Instrument")]
        public int Instrument { get; internal set; }
        [JsonProperty("Side")]
        public string Side { get; internal set; }
        [JsonProperty("OrderId")]
        public int OrderId { get; internal set; }
        [JsonProperty("Price")]
        public decimal Price { get; internal set; }
        [JsonProperty("OrderState")]
        public string OrderState { get; internal set; }
        [JsonProperty("OrigQuantity")]
        public decimal OrigQuantity { get; internal set; }
        [JsonProperty("QuantityExecuted")]
        public decimal QuantityExecuted { get; internal set; }
        [JsonProperty("RejectReason")]
        public string RejectReason { get; internal set; }
        [JsonProperty("OrigOrderId")]
        public int OrigOrderId { get; internal set; }
        [JsonProperty("RecieveTime")]
        public long RecieveTime { get; internal set; }
    }
}
