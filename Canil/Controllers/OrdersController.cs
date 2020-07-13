using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Canil.Models;
using Canil.Models.OrdersAdmin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Canil.Controllers
{
    [Route("[controller]")]
    [Authorize(Policy = "Admin")]
    public class OrdersController : Controller
    {
        private ApplicationDbContext _ctx;

        public OrdersController(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet("")]
        public IActionResult GetOrders(int status) => Ok(new GetOrders(_ctx).Do(status));

        [HttpGet("{id}")]
        public IActionResult GetOrder(int id) => Ok(new GetOrder(_ctx).Do(id));

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id) => Ok(await new UpdateOrder(_ctx).Do(id));
    }
}