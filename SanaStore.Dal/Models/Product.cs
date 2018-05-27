﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SanaStore.Dal.Models
{
    public class Product : Entity
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
