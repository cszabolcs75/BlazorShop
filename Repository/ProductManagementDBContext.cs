using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductManagementDBContext: DbContext
    {
        public ProductManagementDBContext(DbContextOptions<ProductManagementDBContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Shoes",
                    Price = 500,
                    ManufactureDate = DateTime.UtcNow,
                    IsAvailable = true,
                    StockCount = 50 
                },
                new Product
                {
                    Id = 2,
                    Name = "T-Shirt",
                    Price = 200,
                    ManufactureDate = DateTime.UtcNow,
                    IsAvailable = true,
                    StockCount = 100
                },
                new Product
                {
                    Id = 3,
                    Name = "Jeans",
                    Price = 600,
                    ManufactureDate = DateTime.UtcNow,
                    IsAvailable = false,
                    StockCount = 80
                });
        }
    }
}
