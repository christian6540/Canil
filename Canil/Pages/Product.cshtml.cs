using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Canil.Models;
using Canil.Models.ProductsAdmin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Canil.Pages
{
    public class ProductModel : PageModel
    {
        private ApplicationsDbContext _ctx;

        public ProductModel(ApplicationsDbContext ctx)
        {
            _ctx = ctx;
        }

        [BindProperty]
        public Test ProductTest { get; set; }

        public class Test
        {
            public string Id { get; set; }
        }

        public GetProduct2.ProductViewModel Product { get; set; }

        public IActionResult OnGet(string name)
        {
            Product = new GetProduct2(_ctx).Do(name.Replace("-", " "));
            if (Product == null)
            {
                return RedirectToPage("IndexLoja");
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPost()
        {
            var current_id = HttpContext.Session.GetString("id");

            HttpContext.Session.SetString("id", ProductTest.Id);

            return RedirectToPage("IndexLoja");
        }

    }
}