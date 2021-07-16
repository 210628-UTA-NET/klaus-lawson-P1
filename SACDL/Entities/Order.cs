using System;
using System.Collections.Generic;

#nullable disable

namespace SACDL.Entities
{
    public partial class Order
    {
        public Order()
        {
            LineItems = new HashSet<LineItem>();
        }

        public int OrdersId { get; set; }
        public string OrdersLocation { get; set; }
        public decimal OrdersTotalPrice { get; set; }
        public int? StoreFrontId { get; set; }
        public int? CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual StoreFront StoreFront { get; set; }
        public virtual ICollection<LineItem> LineItems { get; set; }
    }
}
