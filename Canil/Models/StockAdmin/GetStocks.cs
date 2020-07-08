using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Canil.Models.StockAdmin
{
    public class GetStocks
    {
        private ApplicationsDbContext _ctx;

        public GetStocks(ApplicationsDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<StockViewModel> Do(int productId)
        {
            var stock = _ctx.Stock
                .Where(x => x.ProductId == productId)
                .Select(x => new StockViewModel {
                    Id = x.Id,
                    Description = x.Description,
                    Qty = x.Qty,
                })
                .ToList();


            return stock;
        }


        public class StockViewModel
        {
            public int Id { get; set; }
            public int ProductId { get; set; }
            public string Description { get; set; }
            public int Qty { get; set; }
        }
    }
}

