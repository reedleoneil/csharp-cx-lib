using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXlib
{
    public class Instrument
    {
        [JsonProperty("InstrumentId")]
        public int InstrumentId { get; private set; }
        [JsonProperty("Symbol")]
        public string Symbol { get; private set; }
        [JsonProperty("Product1")]
        public int Product1 { get; private set; }
        [JsonProperty("Product1Symbol")]
        public string Product1Symbol { get; private set; }
        [JsonProperty("Product2")]
        public int Product2 { get; private set; }
        [JsonProperty("Product2Symbol")]
        public string Product2Symbol { get; private set; }
        [JsonProperty("InstrumentType")]
        public string InstrumentType { get; private set; }
    }
}
