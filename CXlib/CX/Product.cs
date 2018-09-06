using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXlib
{
    public class Product
    {
        [JsonProperty("ProductId")]
        public int ProductId { get; private set; }
        [JsonProperty("Product")]
        public string Symbol { get; private set; }
        [JsonProperty("ProductFullName")]
        public string ProductFullName { get; private set; }
        [JsonProperty("ProductType")]
        public string ProductType { get; private set; }
        [JsonProperty("DecimalPlaces")]
        public int DecimalPlaces { get; private set; }
    }
}
