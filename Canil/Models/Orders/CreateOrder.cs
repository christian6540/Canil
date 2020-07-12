using Canil.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Canil.Models.Orders
{
    public class CreateOrder
    {
        private ApplicationDbContext _ctx;

        public CreateOrder(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public class Request
        {
            public string StripeReference { get; set; }

            public string SessionId { get; set; }

            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string Email { get; set; }

            public string PhoneNumber { get; set; }

            public string Adress1 { get; set; }

            public string Adress2 { get; set; }

            public string City { get; set; }

            public string PostCode { get; set; }

            public List<Stock> Stocks { get; set; }
        }

        public class Stock
        {
            public int StockId { get; set; }
            public int Qty { get; set; }
        }

        public async Task<bool> Do(Request request)
        {
            var StockOnHold = _ctx.StocksOnHold.AsEnumerable().Where(x => x.SessionId == request.SessionId).ToList();

            _ctx.StocksOnHold.RemoveRange(StockOnHold);

            var Order = new Order
            {
                OrderRef = CreateOrderReference(),

                StripeReference = request.StripeReference,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Adress1 = request.Adress1,
                Adress2 = request.Adress2,
                City = request.City,
                PostCode = request.PostCode,

                OrderStocks = request.Stocks.Select(x => new OrderStock
                {
                    StockId = x.StockId,
                    Qty = x.Qty,
                }).ToList()
            };

            _ctx.Orders.Add(Order);

            return await _ctx.SaveChangesAsync() > 0;
        }

        public string CreateOrderReference()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVXYZabcdefghijkmlmnopqrstuvxyz0123456789";
            var Result = new char[12];
            var Random = new Random();

            do
            {
                for (int i = 0; i < Result.Length; i++)
                {
                    Result[i] = chars[Random.Next(chars.Length)];
                }
            }
            while (_ctx.Orders.Any(x => x.OrderRef == new string(Result)));

            return new string(Result);
        }
    }
}