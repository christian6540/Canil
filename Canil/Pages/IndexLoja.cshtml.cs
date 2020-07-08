using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Canil.Models.Products;
using Canil.Models;
using Canil.Models.ProductsAdmin;

namespace Canil.Pages
{
    public class IndexLojaModel : PageModel
    {
        private ApplicationsDbContext _ctx;

        public IndexLojaModel(ApplicationsDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<GetProducts2.ProductViewModel> Products { get; set; }

        public void OnGet()
        {
            Products = new GetProducts2(_ctx).Do();
        }
    }
}