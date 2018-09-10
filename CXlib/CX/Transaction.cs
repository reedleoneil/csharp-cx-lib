using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXlib
{
    public class Transaction
    {
        [JsonProperty("TransactionId")]
        public int TransactionId { get; internal set; }
        [JsonProperty("AccountId")]
        public int AccountId { get; internal set; }
        [JsonProperty("CR")]
        public decimal Cr { get; internal set; }
        [JsonProperty("DR")]
        public decimal Dr { get; internal set; }
        [JsonProperty("TransactionType")]
        public string TransactionType { get; internal set; }
        [JsonProperty("ReferenceId")]
        public int ReferenceId { get; internal set; }
        [JsonProperty("ProductId")]
        public int ProductId { get; internal set; }
        [JsonProperty("Balance")]
        public decimal Balance { get; internal set; }
        [JsonProperty("ReferenceType")]
        public string ReferenceType { get; internal set; }
        [JsonProperty("TimeStamp")]
        public long TimeStamp { get; internal set; }
    }
}
