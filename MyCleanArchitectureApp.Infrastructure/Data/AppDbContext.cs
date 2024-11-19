using Microsoft.EntityFrameworkCore;
using MyCleanArchitectureApp.Domain.Entities;
using MyCleanArchitectureApp.Infrastructure.Data.Configurations;

namespace MyCleanArchitectureApp.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 1,
                    Name = "IPhone X",
                    Price = 799.99M,
                    Stock = 200
                },
                new Product()
                {
                    Id = 2,
                    Name = "IPhone 12",
                    Price = 799.99M,
                    Stock = 200
                },
                new Product()
                {
                    Id = 3,
                    Name = "IPhone 14",
                    Price = 799.99M,
                    Stock = 200
                }
            );

            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}
