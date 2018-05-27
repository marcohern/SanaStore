using System;
using System.Collections.Generic;
using System.Text;

namespace SanaStore.Dal.Models
{
    public class Order : Entity
    {
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public DateTime RecordedDate { get; set; }

        public decimal Total { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
