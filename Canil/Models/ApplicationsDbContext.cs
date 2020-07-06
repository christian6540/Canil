using Canil.Models.Products;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Canil.Models
{
    public class ApplicationsDbContext : IdentityDbContext
    {
        public ApplicationsDbContext(DbContextOptions<ApplicationsDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
