using Canil.Models.Products;
using System.Threading.Tasks;

namespace Canil.Models.StockAdmin
{
    public class CreateStock
    {
        private ApplicationDbContext _ctx;

        public CreateStock(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Response> Do(Request request)
        {
            var stock = new Stock
            {
                description = request.description,
                qty = request.qty,
                productId = request.productId
            };

            _ctx.Stock.Add(stock);

            await _ctx.SaveChangesAsync();

            return new Response
            {
                id = stock.Id,
                description = stock.description,
                qty = stock.qty
            };
        }

        public class Request
        {
            public string description { get; set; }
            public int qty { get; set; }
            public int productId { get; set; }
        }

        public class Response
        {
            public int id { get; set; }
            public string description { get; set; }
            public int qty { get; set; }
        }
    }
}