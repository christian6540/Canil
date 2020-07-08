﻿using Canil.Models.Products;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Canil.Models
{
    public class ApplicationsDbContext : IdentityDbContext
    {
        public ApplicationsDbContext(DbContextOptions<ApplicationsDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProduct { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OrderProduct>()
                .HasKey(x => new { x.ProductId, x.OrderId });
        }
    }
}
