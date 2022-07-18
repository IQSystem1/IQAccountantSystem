using IQ.Accountant.System.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace IQ.Accountant.System.Model
{
    public class IQAccountantSystemContext : DbContext
    {
        public IQAccountantSystemContext(DbContextOptions options) : base(options) { }
        public DbSet<Product> products { get; set; }
        public DbSet<ImageVideo> imageVideos { get; set; }
        public DbSet<ProductImageVideo> productImageVideos { get; set; }
        public DbSet<User> users{ get; set; }

        public DbSet<Sale> sales { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>()
                .Property(p => p.ProductCode).IsRequired();
            builder.Entity<User>()
                .HasIndex(p => p.UserName).IsUnique();
        }
    }
}
