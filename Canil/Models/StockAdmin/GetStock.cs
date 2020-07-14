﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Canil.Models.StockAdmin
{
    public class GetStock
    {
        private ApplicationDbContext _ctx;

        public GetStock(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<ProductViewModel> Do()
        {
            var stock = _ctx.Products
                .Include(x => x.Stock)
                .Select(x => new ProductViewModel
                {
                    Id = x.Id,
                    Description = x.Description,
                    Stock = x.Stock.Select(y =>

                    new StockViewModel
                    {
                        Id = y.Id,
                        Description = y.description,
                        Qty = y.qty,
                    })
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

        public class ProductViewModel
        {
            public int Id { get; set; }
            public string Description { get; set; }

            public IEnumerable<StockViewModel> Stock { get; set; }
        }
    }
}