using Canil.Areas.Identity.Data;
using Canil.Migrations.ApplicationsDb;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Canil.Data
{
    public class CanilContext : IdentityDbContext<CanilUser>
    {
        public CanilContext(DbContextOptions<CanilContext> options)
            : base(options)
        {
        }

        public DbSet<Areas.Identity.Data.Doação> Doação { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            base.OnModelCreating(builder);
            builder.Entity<Areas.Identity.Data.Doação>()
                .HasKey(x => new { x.Id });
        }
    }
}