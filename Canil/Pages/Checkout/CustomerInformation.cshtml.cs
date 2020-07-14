using Canil.Models.Cart;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;

namespace Canil.Pages.Checkout
{
    public class CustomerInformationModel : PageModel
    {
        private IHostEnvironment _env;

        public CustomerInformationModel(IHostEnvironment env)
        {
            _env = env;
        }

        [BindProperty]
        public AddCustomerInformation.Request CustomerInformation { get; set; }

        public IActionResult OnGet()
        {
            var information = new GetCustomerInformation(HttpContext.Session).Do();

            if (information == null)
            {
                //if (_env.IsDevelopment())
                //{
                //    CustomerInformation = new AddCustomerInformation.Request
                //    {
                //        FirstName = "A",
                //        LastName = "A",
                //        Email = "A@A.com",
                //        PhoneNumber = "11",
                //        Adress1 = "A",
                //        Adress2 = "A",
                //        City = "A",
                //        PostCode = "A",
                //    };
                //}
                return Page();
            }
            else
            {
                return RedirectToPage("/Checkout/Payment");
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            new AddCustomerInformation(HttpContext.Session).Do(CustomerInformation);

            return RedirectToPage("/Checkout/Payment");
        }
    }
}