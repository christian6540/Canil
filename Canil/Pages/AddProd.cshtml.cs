using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Canil.Models;
using Canil.Models.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Canil.Pages
{
    public class AddProdModel : PageModel
    {
        private ApplicationsDbContext _ctx;

        public AddProdModel(ApplicationsDbContext ctx)
        {
            _ctx = ctx;
        }

        [BindProperty]
        public ProductViewModel Product { get; set; }

        public class ProductViewModel
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Value { get; set; }
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            await new CreateProduct(_ctx).Do(Product.Name, Product.Description, Product.Value);

            return RedirectToPage("AddProd");
        }
    }
}