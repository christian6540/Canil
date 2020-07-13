using System;
using System.Linq;
using Canil.Models.Cart;
using Canil.Models.Orders;
using Canil.Models.Valores;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Stripe;

namespace Canil.Models
{
    public class ServerDoação
    {
        public static void Principal(string[] args)
        {
            WebHost.CreateDefaultBuilder(args)
              .UseUrls("http://0.0.0.0:4242")
              .UseWebRoot(".")
              .UseStartup<Startup>()
              .Build()
              .Run();
        }
    }

    public class StartupDoação
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddNewtonsoftJson();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // This is your real test secret API key.
            StripeConfiguration.ApiKey = "sk_test_51H1jaqGi8iMKIvEmlFiPYRq9ysCdA9VSNEfM5fGsSZ0TwbeKTegy9cwG1qtmPGKrwwERYCVhTHmhy7CRaGvUfgSI00Z9YLCstr";
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            app.UseRouting();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }

    [Route("create-payment-intent")]
    [ApiController]
    public class PaymentIntentApiDoaçãoController : Controller
    {
        public string PublicKey { get; }

        private ApplicationDbContext _ctx;

        public PaymentIntentApiDoaçãoController(IConfiguration configuration, ApplicationDbContext ctx)
        {
            PublicKey = configuration["Stripe:PublicKey"].ToString();
            _ctx = ctx;
        }

        [HttpPost]
        public ActionResult Create(PaymentIntentCreateRequest request, string stripeEmail, string stripeToken, [FromForm] Doação model)
        {
            var cartOrder = new Cart.GetOrder(HttpContext.Session, _ctx).Do();
            var customers = new CustomerService();
            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = stripeEmail,
                Source = stripeToken
            });

            var paymentIntents = new PaymentIntentService();
            var paymentIntent = paymentIntents.Create(new PaymentIntentCreateOptions
            {
                //Amount = CalculateOrderAmount(request.Items),
                //Currency = "eur",
                Amount = model.Valor,
                Description = "Shop Purchase",
                Currency = "eur",
                Customer = customer.Id
            });

            return Json(new { clientSecret = paymentIntent.ClientSecret });
        }

        private int CalculateOrderAmount(Item[] items)
        {
            // Replace this constant with a calculation of the order's amount
            // Calculate the order total on the server to prevent
            // people from directly manipulating the amount on the client
            return 1400;
        }

        public class Item
        {
            [JsonProperty("id")]
            public string Id { get; set; }
        }

        public class PaymentIntentCreateRequest
        {
            [JsonProperty("items")]
            public Item[] Items { get; set; }
        }
    }
}