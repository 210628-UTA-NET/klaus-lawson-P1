using System;
using System.Collections.Generic;
using SACModels;

namespace SACDL
{
    public interface IRepository
    {
        // Customer Operations
        public Customer  AddCustomer(Customer p_customer);
        public Customer DeleteCustomer(int p_id);
        public Customer UpdateCustomer (int p_id);
        public Customer FindCustomer (string p_searchKey);
        public List<Customer> GetAllCustomer();
        
        // StoreFront Operations
        public StoreFront FindStoreFront(string p_searchKey);
        public StoreFront FindStoreFrontByID(int p_stfID);
        public List<Product> GetStoreFrontProducts(string p_storeName);

        //Product Operations
        public Product FindProduct(int p_id);
        public bool UpdateProduct(int p_id, Product p_Product);
        public bool AddProduct (Product p_product);
        public List<StoreFront> GetAllStoreFront();
         public bool AddNewOrder(Orders p_orders);
         public int GetLastOrderId();
         public bool AddLineItems(LineItems p_lineItems);
         public List<Orders> GetOrderOfCustomer(int p_customerID);
        
    }
}
