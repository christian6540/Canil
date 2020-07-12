using Canil.Models;
using Canil.Models.Cart;
using Canil.Models.ProductsAdmin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Canil.Pages
{
    public class ProductModel : PageModel
    {
        private ApplicationDbContext _ctx;

        public ProductModel(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        [BindProperty]
        public AddToCart.Request CartViewModel { get; set; }

        public GetProduct2.ProductViewModel Product { get; set; }

        public async Task<IActionResult> OnGet(string name)
        {
            Product = await new GetProduct2(_ctx).Do(name.Replace("-", " "));
            if (Product == null)
            {
                return RedirectToPage("IndexLoja");
            }
            else
            {
                return Page();
            }
        }

        public async Task<IActionResult> OnPost()
        {
            //var current_id = HttpContext.Session.GetString("id");
            //HttpContext.Session.SetString("id", ProductTest.Id);

            var stockAdded = await new AddToCart(HttpContext.Session, _ctx).Do(CartViewModel);

            if (stockAdded)
            {
                return RedirectToPage("IndexLoja");
            }
            else
            {
                return Page();
            }
        }
    }
}