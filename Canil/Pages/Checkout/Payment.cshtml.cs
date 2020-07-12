using Canil.Models;
using Canil.Models.Cart;
using Canil.Models.Orders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using Stripe;
using System.Linq;
using System.Threading.Tasks;

namespace Canil.Pages.Checkout
{
    public class PaymentModel : PageModel
    {
        public string PublicKey { get; }

        private ApplicationDbContext _ctx;

        public PaymentModel(IConfiguration configuration, ApplicationDbContext ctx)
        {
            PublicKey = configuration["Stripe:PublicKey"].ToString();
            _ctx = ctx;
        }

        public IActionResult OnGet()
        {
            var information = new GetCustomerInformation(HttpContext.Session).Do();

            if (information == null)
            {
                return RedirectToPage("/Checkout/CustomerInformation");
            }

            return Page();
        }

        public async Task<IActionResult> OnPost(string stripeEmail, string stripeToken)
        {
            var customers = new CustomerService();
            var charges = new ChargeService();

            var cartOrder = new Models.Cart.GetOrder(HttpContext.Session, _ctx).Do();

            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = stripeEmail,
                Source = stripeToken
            });

            //var charge = charges.Create(new ChargeCreateOptions
            //{
            //    Amount = cartOrder.GetTotalCharge(),
            //    Description = "Shop Purchase",
            //    Currency = "gbp",
            //    Customer = customer.Id
            //});

            var paymentIntents = new PaymentIntentService();
            var paymentIntent = paymentIntents.Create(new PaymentIntentCreateOptions
            {
                //Amount = CalculateOrderAmount(request.Items),
                //Currency = "eur",
                Amount = cartOrder.GetTotalCharge(),
                Description = "Shop Purchase",
                Currency = "eur",
                Customer = customer.Id
            });

            var sessionId = HttpContext.Session.Id;

            await new CreateOrder(_ctx).Do(new CreateOrder.Request
            {
                StripeReference = paymentIntent.Id,
                SessionId = sessionId,

                FirstName = cartOrder.CustomerInformation.FirstName,
                LastName = cartOrder.CustomerInformation.LastName,
                Email = cartOrder.CustomerInformation.Email,
                PhoneNumber = cartOrder.CustomerInformation.PhoneNumber,
                Adress1 = cartOrder.CustomerInformation.Adress1,
                Adress2 = cartOrder.CustomerInformation.Adress2,
                City = cartOrder.CustomerInformation.City,
                PostCode = cartOrder.CustomerInformation.PostCode,

                Stocks = cartOrder.Products.Select(x => new CreateOrder.Stock
                {
                    StockId = x.StockId,
                    Qty = x.Qty,
                }).ToList()
            }); ;

            return RedirectToPage("/IndexLoja");
        }
    }
}