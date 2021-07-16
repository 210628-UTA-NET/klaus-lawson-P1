using System;
using System.Collections.Generic;

#nullable disable

namespace SACDL.Entities
{
    public partial class LineItem
    {
        public int LineItemsId { get; set; }
        public decimal LineItemsProductQuantity { get; set; }
        public int? ProductId { get; set; }
        public int? OrdersId { get; set; }

        public virtual Order Orders { get; set; }
        public virtual Product Product { get; set; }
    }
}
