using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Canil.Models.ProductsAdmin
{
    public class GetProducts
    {
        private ApplicationsDbContext _ctx;

        public GetProducts(ApplicationsDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<ProductViewModel> Do() =>
            _ctx.Products.ToList().Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
                //Description = x.Description,
                Value = x.Value
            });

        public class ProductViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            //public string Description { get; set; }
            public decimal Value { get; set; }
        }
    }        
}
