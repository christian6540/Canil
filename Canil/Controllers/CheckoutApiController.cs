using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Canil.Controllers
{
    [Route("id")]
    [ApiController]
    public class CheckoutApiController : Controller
    {
        private ISession _session;

        public CheckoutApiController(ISession session)
        {
            _session = session;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Json(new { session_id = _session.Id });
        }
    }
}