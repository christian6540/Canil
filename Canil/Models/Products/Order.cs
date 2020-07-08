using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Canil.Models.Products
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderRef { get; set; }
        public int Adress1 { get; set; }
        public int Adress2 { get; set; }
        public int City { get; set; }
        public int PostCode { get; set; }

        public ICollection<OrderProduct> OrderProduct { get; set; }
    }
}
