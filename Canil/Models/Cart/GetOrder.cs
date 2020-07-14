﻿using Canil.Models.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Canil.Models.Cart
{
    public class GetOrder
    {
        private ISession _session;
        private ApplicationDbContext _ctx;

        public GetOrder(ISession session, ApplicationDbContext ctx)
        {
            _session = session;
            _ctx = ctx;
        }

        public class Response
        {
            public IEnumerable<Product> Products { get; set; }
            public CustomerInformation CustomerInformation { get; set; }

            public int GetTotalCharge() => Products.Sum(x => x.Value * x.Qty);
        }

        public class Product
        {
            public int ProductId { get; set; }
            public int StockId { get; set; }
            public int Qty { get; set; }
            public int Value { get; set; }
        }

        public class CustomerInformation
        {
            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string Email { get; set; }

            public string PhoneNumber { get; set; }

            public string Adress1 { get; set; }

            public string Adress2 { get; set; }

            public string City { get; set; }

            public string PostCode { get; set; }
        }

        public Response Do()
        {
            var cart = _session.GetString("cart");

            var cartList = JsonConvert.DeserializeObject<List<CartProduct>>(cart);

            var listOfProducts = _ctx.Stock
                .Include(x => x.Product).AsEnumerable()
                .Where(x => cartList.Any(y => y.StockId == x.Id))
                .Select(x => new Product
                {
                    ProductId = x.productId,
                    StockId = x.Id,
                    Value = (int)(x.Product.Value * 100),
                    Qty = cartList.FirstOrDefault(y => y.StockId == x.Id).Qty
                }).ToList();

            var customerInfoString = _session.GetString("customer-info");

            var customerInformation = JsonConvert.DeserializeObject<Canil.Models.Products.CustomerInformation>(customerInfoString);

            return new Response
            {
                Products = listOfProducts,
                CustomerInformation = new CustomerInformation
                {
                    FirstName = customerInformation.FirstName,
                    LastName = customerInformation.LastName,
                    Email = customerInformation.Email,
                    PhoneNumber = customerInformation.PhoneNumber,
                    Adress1 = customerInformation.Adress1,
                    Adress2 = customerInformation.Adress2,
                    City = customerInformation.City,
                    PostCode = customerInformation.PostCode,
                }
            };
        }
    }
}