using System.Collections.Generic;
using System.Threading.Tasks;
using Canil.Models;
using Canil.Models.CreateProducts;
using Canil.Models.GetProducts;
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
        public CreateProduct.ProductViewModel Product { get; set; }      

        public IEnumerable<Models.GetProducts.ProductViewModel> Products { get; set; }

        public void OnGet()
        {
            Products = new GetProducts(_ctx).Do();
        }

        public async Task<IActionResult> OnPost()
        {
            await new CreateProduct(_ctx).Do(Product);

            return RedirectToPage("AddProd");
        }
    }
}