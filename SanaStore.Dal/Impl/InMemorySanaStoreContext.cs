using Microsoft.EntityFrameworkCore;
using SanaStore.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SanaStore.Dal.Impl
{
    public class InMemorySanaStoreContext : DbContext, ISanaStoreContext
    {
        public InMemorySanaStoreContext(DbContextOptions<InMemorySanaStoreContext> options) 
            : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public void AddSeedData()
        {
            Customers.AddRange(new List<Customer> {
                new Customer{ Name="Marco Hernandez", Email="marcohern@gmail.com" }
            });

            Categories.AddRange(new List<Category> {
                new Category{ Name="Action" },
                new Category{ Name="Adventure" },
                new Category{ Name="Puzzle" },
                new Category{ Name="Horror" },
                new Category{ Name="Adult" },
                new Category{ Name="RPG" }
            });

            Products.AddRange(new List<Product> {
                new Product{ Name="Destiny", Price=40.00m },
                new Product{ Name="Destiny 2", Price=45.00m },
                new Product{ Name="Resident Evil VII", Price=60.00m },
                new Product{ Name="Dead Space", Price=15.00m },
                new Product{ Name="Doom", Price=30.00m },
                new Product{ Name="Minecraft", Price=12.00m },
            });

            ProductCategories.AddRange(new List<ProductCategory> {
                new ProductCategory{ ProductId=1, CategoryId=1 },
                new ProductCategory{ ProductId=1, CategoryId=2 },
                new ProductCategory{ ProductId=1, CategoryId=6 },
                new ProductCategory{ ProductId=2, CategoryId=1 },
                new ProductCategory{ ProductId=2, CategoryId=2 },
                new ProductCategory{ ProductId=2, CategoryId=6 },
                new ProductCategory{ ProductId=3, CategoryId=3 },
                new ProductCategory{ ProductId=3, CategoryId=4 },
                new ProductCategory{ ProductId=4, CategoryId=2 },
                new ProductCategory{ ProductId=4, CategoryId=4 },
                new ProductCategory{ ProductId=5, CategoryId=1 },
                new ProductCategory{ ProductId=5, CategoryId=5 },
                new ProductCategory{ ProductId=6, CategoryId=2 },
                new ProductCategory{ ProductId=6, CategoryId=3 },
            });

            SaveChanges();
        }
    }
}
