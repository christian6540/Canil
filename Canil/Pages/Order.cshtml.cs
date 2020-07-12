using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Canil.Models;
using Canil.Models.Orders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Canil.Pages
{
    public class OrderModel : PageModel
    {
        private ApplicationDbContext _ctx;

        public OrderModel(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public GetOrder.Response Order { get; set; }

        public void OnGet(string reference)
        {
            Order = new GetOrder(_ctx).Do(reference);
        }
    }
}