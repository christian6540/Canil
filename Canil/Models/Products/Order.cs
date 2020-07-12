﻿using System.Collections.Generic;

namespace Canil.Models.Products
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderRef { get; set; }
        public string StripeReference { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string Adress1 { get; set; }
        public string Adress2 { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }

        public ICollection<OrderStock> OrderStocks { get; set; }
    }
}