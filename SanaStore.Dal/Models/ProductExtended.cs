using System;
using System.Collections.Generic;
using System.Text;

namespace SanaStore.Dal.Models
{
    public class ProductExtended
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
    }
}
