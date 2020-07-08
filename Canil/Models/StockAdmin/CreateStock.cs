using Canil.Models.Products;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Canil.Models.StockAdmin
{
    public class CreateStock
    {
        private ApplicationsDbContext _ctx;

        public CreateStock(ApplicationsDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Response> Do(Request request)
        {
            var stock = new Stock
            {
                Description = request.Description,
                Qty = request.Qty,
                ProductId = request.ProductId
            };

            _ctx.Stock.Add(stock);

            await _ctx.SaveChangesAsync();

            return new Response
            {
                Id = stock.Id,
                Description = stock.Description,
                Qty = stock.Qty
            };
                
        }

        public class Request
        {
            public string Description { get; set; }
            public int Qty { get; set; }
            public int ProductId { get; set; }
        }

        public class Response
        {
            public int Id { get; set; }
            public string Description { get; set; }
            public int Qty { get; set; }           
        }

    }
}
