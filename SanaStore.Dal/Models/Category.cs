using System;
using System.Collections.Generic;
using System.Text;

namespace SanaStore.Dal.Models
{
    public class Category : Entity
    {
        public string Name { get; set; }

        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
