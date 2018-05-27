using System;
using System.Collections.Generic;
using System.Text;

namespace SanaStore.Dal.Models
{
    public class OrderDetail : Entity
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Qty { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal TotalPrice { get; set; }

        public Order Order { get; set; }

        public Product Product { get; set; }
    }
}
