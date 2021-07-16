using System;
using System.Collections.Generic;

#nullable disable

namespace SACDL.Entities
{
    public partial class Product
    {
        public Product()
        {
            LineItems = new HashSet<LineItem>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
        public string Productdescription { get; set; }
        public string Productcategory { get; set; }
        public int? StoreFrontId { get; set; }

        public virtual StoreFront StoreFront { get; set; }
        public virtual ICollection<LineItem> LineItems { get; set; }
    }
}
