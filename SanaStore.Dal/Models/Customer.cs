using System;
using System.Collections.Generic;
using System.Text;

namespace SanaStore.Dal.Models
{
    public class Customer : Entity
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
