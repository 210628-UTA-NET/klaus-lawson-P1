using SAModels;
using System;
using System.Collections.Generic;

namespace SADL
{
    public interface IRepository
    {
        // Customer Operations
        public Customer AddCustomer(Customer p_customer);
        public Customer FindCustomerByKey(string p_searchKey);
        public Customer UpdateCustomerById(int p_id);
        public bool DeleteCustomerById(int p_id);
        public bool DeleteCustomer(Customer p_cust);
        public List<Customer> GetAllCustomers();

        //Store Operations
        public List<Store> GetAllStores();
        public Store GetStoreById(int p_Id);
        public List<Store> GetAllStoresWhithAddress();

        //Address Operation       
        public Address GetAddressById(int p_Id);
        public List<Address> GetAllAddress();

        //Product Operations
        public List<Product> GetAllProducts();
        public List<Product> GetProductsByStoreId(int p_storeId);
        public Product GetProductById(int p_productId);
    }
}
