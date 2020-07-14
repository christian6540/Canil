using System.Collections.Generic;

namespace Canil.Models.Products
{
    public class Stock
    {
        public int Id { get; set; }
        public string description { get; set; }
        public int qty { get; set; }

        public int productId { get; set; }
        public Product Product { get; set; }

        public ICollection<OrderStocks> OrderStocks { get; set; }
    }
}