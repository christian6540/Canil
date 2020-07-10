using Canil.Models;
using Canil.Models.ProductsAdmin;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Canil.Pages
{
    public class IndexLojaModel : PageModel
    {
        private ApplicationDbContext _ctx;

        public IndexLojaModel(ApplicationDbContext ctx)
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