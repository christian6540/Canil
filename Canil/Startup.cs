using Canil.Data;
using Canil.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Stripe;
using System;

namespace Canil
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CanilContext>(options =>
                options.UseMySql(
                    Configuration.GetConnectionString("DefaultConnection")));
            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<CanilContext>();

            services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy => policy.RequireClaim("Admin"));
                options.AddPolicy("Manager", policy => policy.RequireClaim("Manager"));
            });

            services.ConfigureApplicationCookie(options => options.LoginPath = "/Identity/Account/Login");

            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddSession(options =>
            {
                options.Cookie.Name = "Cart";
                options.Cookie.MaxAge = TimeSpan.FromMinutes(20);
            });
            services.Configure<StripeSettings>(Configuration.GetSection("Stripe"));
            StripeConfiguration.ApiKey = Configuration.GetSection("Stripe")["SecretKey"];
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}