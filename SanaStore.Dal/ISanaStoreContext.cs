using Microsoft.EntityFrameworkCore;
using SanaStore.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SanaStore.Dal
{
    public interface ISanaStoreContext : IDisposable
    {
        DbSet<Customer> Customers { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<ProductCategory> ProductCategories { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderDetail> OrderDetails { get; set; }

        int SaveChanges();
    }
}
