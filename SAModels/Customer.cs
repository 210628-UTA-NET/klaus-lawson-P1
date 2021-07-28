using System;
using System.Collections.Generic;


namespace SAModels
{
    public class Customer
    {

        public int Id { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerRole { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerPassword { get; set; }
       public List<Order> CustomerOrders { get; set; }
        public int CustomerAddressId { get; set; }
        public Address CustomerAddress { get; set; }

    }
}
