using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace BusinessObjects
{
    public class MyStockDBContext : DbContext
    {
        public DbSet<AccountMember> AccountMembers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyNewStockDB"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(category => category.CategoryName)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(product => product.ProductId);

                entity.Property(product => product.ProductName)
                .IsRequired()
                .HasMaxLength(100);

                entity.Property(product => product.UnitPrice)
                .IsRequired()
                .HasColumnType("decimal(18, 2)");

                entity.Property(product => product.UnitsInStock)
                .HasDefaultValue(0);

                entity.HasOne(product => product.Category)
                .WithMany(category => category.Products)
                .HasForeignKey(product => product.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Category>().HasData(
               new Category { CategoryId = 1, CategoryName = "Beverages" },
               new Category { CategoryId = 2, CategoryName = "Condiments" },
               new Category { CategoryId = 3, CategoryName = "Confections" }
           );

            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, ProductName = "Chai", CategoryId = 1, UnitsInStock = 39, UnitPrice = 18.00m },
                new Product { ProductId = 2, ProductName = "Chang", CategoryId = 1, UnitsInStock = 17, UnitPrice = 19.00m },
                new Product { ProductId = 3, ProductName = "Aniseed Syrup", CategoryId = 2, UnitsInStock = 13, UnitPrice = 10.00m },
                new Product { ProductId = 4, ProductName = "Chef Anton's Cajun Seasoning", CategoryId = 2, UnitsInStock = 53, UnitPrice = 22.00m },
                new Product { ProductId = 5, ProductName = "Grandma's Boysenberry Spread", CategoryId = 2, UnitsInStock = 120, UnitPrice = 25.00m },
                new Product { ProductId = 6, ProductName = "Chocolate Cake", CategoryId = 3, UnitsInStock = 21, UnitPrice = 15.00m }
            );
        }
    }
}