using Canil.Areas.Identity.Data;
using Canil.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Canil.Areas.Identity.IdentityHostingStartup))]

namespace Canil.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<CanilContext>(options =>
                    options.UseMySql(
                        context.Configuration.GetConnectionString("DefaultConnection")));

                services.AddDefaultIdentity<CanilUser>(options => options.SignIn.RequireConfirmedAccount = false)//true for email confirmation
                    .AddEntityFrameworkStores<CanilContext>();
            });
        }
    }
}