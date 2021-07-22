using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAModels
{
    public class Product
    {
        public Product()
        {
            this.LineItems = new List<LineItem>();
        }
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductAvailableQty { get; set; }
        public double ProductUnitPrice { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int StoreId { get; set; }
        public Store Store { get; set; }
        public List<LineItem> LineItems { get; set; }
    }
}
