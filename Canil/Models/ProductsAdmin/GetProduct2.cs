﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Canil.Models.ProductsAdmin
{
    public class GetProduct2
    {
        private ApplicationDbContext _ctx;

        public GetProduct2(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<ProductViewModel> Do(string name)
        {
            var stocksOnHold = _ctx.StocksOnHold.Where(x => x.ExpiryDate < DateTime.Now).ToList();

            if (stocksOnHold.Count > 0)
            {
                var stockToReturn = _ctx.Stock.AsEnumerable().Where(x => stocksOnHold.Any(y => y.StockId == x.Id)).ToList();

                foreach (var stock in stockToReturn)
                {
                    stock.Qty = stock.Qty + stocksOnHold.FirstOrDefault(x => x.StockId == stock.Id).Qty;
                }

                _ctx.StocksOnHold.RemoveRange(stocksOnHold);

                await _ctx.SaveChangesAsync();
            }

            return _ctx.Products.Include(x => x.Stock).Where(x => x.Name == name).Select(x => new ProductViewModel
            {
                Name = x.Name,
                Description = x.Description,
                Value = $"{x.Value.ToString("N2")}€",

                Stock = x.Stock.Select(y => new StockViewModel
                {
                    Id = y.Id,
                    Description = y.Description,
                    InStock = y.Qty > 0,
                })
            }).FirstOrDefault();
        }

        public class ProductViewModel
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Value { get; set; }
            public IEnumerable<StockViewModel> Stock { get; set; }
        }

        public class StockViewModel
        {
            public int Id { get; set; }
            public string Description { get; set; }
            public bool InStock { get; set; }
        }
    }
}