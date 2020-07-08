using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Canil.Models.ProductsAdmin
{
    public class GetProducts2
    {
        private ApplicationsDbContext _ctx;

        public GetProducts2(ApplicationsDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<ProductViewModel> Do() =>
            _ctx.Products.ToList().Select(x => new ProductViewModel
            {
                Name = x.Name,
                Description = x.Description,
                Value = $"{x.Value.ToString("N2")}€"
            });

        public class ProductViewModel
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Value { get; set; }
        }
    }        
}
