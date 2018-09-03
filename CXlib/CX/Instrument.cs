using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXlib
{
    public class Instrument
    {
        public int InstrumentId { get; }
        public string Symbol { get; }
        public int Product1 { get; }
        public string Product1Symbol { get;  }
        public int Product2 { get; }
        public string Product2Symbol { get; }
        public string InstrumentType { get; }
        public Instrument(int instrument_id, string symbol, int product_1, string product_1_symbol, int product_2, string product_2_symbol, string instrument_type)
        {
            this.InstrumentId = instrument_id;
            this.Symbol = symbol;
            this.Product1 = product_1;
            this.Product1Symbol = product_1_symbol;
            this.Product2 = product_2;
            this.Product2Symbol = product_2_symbol;
            this.InstrumentType = instrument_type;
        }
    }
}
