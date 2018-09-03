using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXlib
{
    public class Product
    {
        public int ProductId { get; }
        public string Symbol { get; }
        public string ProductFullName { get; }
        public string ProductType { get; }
        public int DeciamPlaces { get; }
        public Product(int product_id, string symbol, string product_full_name, string product_type, int decimal_places)
        {
            this.ProductId = product_id;
            this.Symbol = symbol;
            this.ProductFullName = product_full_name;
            this.ProductType = product_type;
            this.DeciamPlaces = decimal_places;
        }
    }
}
