using SAModels;
using System;
using System.Collections.Generic;

namespace SABL
{
    public interface IStoreAppBL
    {
        /// <summary>
        /// Gets all the Customer from the database
        /// </summary>
        /// <returns>Returns a list of  Customers</returns>

        //Customer Operations

        Customer AddCustomer(Customer p_cust);
        Customer FindCustomerbyKey(string p_searchKey);
        Customer UpdateCustomerById(int p_id);
        bool DeleteCustomerById(int p_id);
        bool DeleteCustomer(Customer p_cust);
        List<Customer> GetAllCustomers();

        //Store Operations
        List<Store> GetAllStores();
        Store GetStoreById(int p_Id);
        List<Store> GetAllStoresWhithAddress();

        //Address Operations

        public Address GetAddressById(int p_Id);
        public List<Address> GetAllAddress();

        //Products Operations
        public List<Product> GetAllProducts();
        public List<Product> GetProductsByStoreId(int p_storeId);
        public Product GetProductById(int p_productId);
    }
}
