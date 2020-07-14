using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Canil.Areas.Identity.Data;
using Canil.Data;
using Canil.Models.Doações;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Canil.Controllers
{
    [Route("[controller]")]
    public class DoaçãoController : Controller
    {
        //private readonly UserManager<CanilUser> _userManager;

        //public DoaçãoController(UserManager<CanilUser> userManager)
        //{
        //    _userManager = userManager;
        //}

        //[HttpGet]
        //public async Task<string> GetCurrentUserId()
        //{
        //    CanilUser usr = await GetCurrentUserAsync();
        //    return usr?.Id;
        //}

        //private Task<CanilUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        private readonly CanilContext _ctx;

        public DoaçãoController(CanilContext ctx)
        {
            _ctx = ctx;
        }

        [HttpPost("doação")]
        public async Task<IActionResult> CriarDoação([FromBody] CriarDoação.Request request) => Ok((await new CriarDoação(_ctx).Do(request)));
    }
}