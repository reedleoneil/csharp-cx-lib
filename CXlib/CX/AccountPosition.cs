using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXlib
{
    public class AccountPosition
    {
        [JsonProperty("AccountId")]
        public int AccountId { get; internal set; }
        [JsonProperty("ProductId")]
        public int ProductId { get; internal set; }
        [JsonProperty("ProductSymbol")]
        public string ProductSymbol { get; internal set; }
        [JsonProperty("Amount")]
        public decimal Amount { get; internal set; }
        [JsonProperty("Hold")]
        public decimal Hold { get; internal set; }
        [JsonProperty("PendingDeposits")]
        public decimal PendingDeposits { get; internal set; }
        [JsonProperty("PendingWithdraws")]
        public decimal PendingWithdraws { get; internal set; }
        [JsonProperty("TotalDayDeposits")]
        public decimal TotalDayDeposits { get; internal set; }
        [JsonProperty("TotalDayWithdraws")]
        public decimal TotalDayWithdraws { get; internal set; }
        [JsonProperty("TotalMonthWithdraws")]
        public decimal TotalMonthWithdraws { get; internal set; }

    }
}
