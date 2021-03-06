﻿using Microsoft.EntityFrameworkCore;
using SanaStore.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SanaStore.Dal.Impl
{
    public class SqlServerSanaStoreContext : DbContext, ISanaStoreContext
    {

        public SqlServerSanaStoreContext(DbContextOptions<SqlServerSanaStoreContext> options)
            : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
