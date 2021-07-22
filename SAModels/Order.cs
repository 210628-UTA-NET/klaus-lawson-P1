using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAModels
{
    public class Order
    {
        public Order()
        {
            this.LineItems = new List<LineItem>();
        }
        public int Id { get; set; }
        public string Location { get; set; }
        public double OrderTotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }
        public int StoreId { get; set; }
        public Store Store { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<LineItem> LineItems { get; set; }
    }
}
