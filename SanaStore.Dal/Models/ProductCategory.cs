using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SanaStore.Dal.Models
{
    public class ProductCategory : Entity
    {
        public int ProductId { get; set; }

        public int CategoryId { get; set; }

        public Product Product { get; set; }

        public Category Category { get; set; }
    }
}
