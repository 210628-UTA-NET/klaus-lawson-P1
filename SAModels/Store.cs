using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAModels
{
    public class Store
    {
        public Store()
        {
            this.StoreOrders = new List<Order>();
            this.StoreProducts = new List<Product>();
        }

        public int Id { get; set; }
        public string StoreName { get; set; }
        public string StorePhone { get; set; }
        public List<Order> StoreOrders { get; set; }
        public List<Product> StoreProducts { get; set; }
        public int StoreAddressId { get; set; }
        public Address StoreAddress { get; set; }
    }
}
