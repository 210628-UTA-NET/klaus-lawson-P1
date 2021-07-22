using SADL;
using SAModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SABL
{
    public class StoreAppBL : IStoreAppBL
    {
        private IRepository _custRepo;
        public StoreAppBL(IRepository p_custRepo)
        {
            _custRepo = p_custRepo;
        }

        //Customer Operation
        public Customer AddCustomer(Customer p_cust)
        {
            return _custRepo.AddCustomer(p_cust);
        }
        public Customer FindCustomerbyKey(string p_searchKey)
        {
            return _custRepo.FindCustomerByKey(p_searchKey);
        }
        public Customer UpdateCustomerById(int p_id)
        {
            return _custRepo.UpdateCustomerById(p_id);
        }
        public bool DeleteCustomerById(int p_id)
        {
            return _custRepo.DeleteCustomerById(p_id);
        }
        public bool DeleteCustomer(Customer p_cust)
        {
            return _custRepo.DeleteCustomer(p_cust);
        }
        public List<Customer> GetAllCustomers()
        {
            return _custRepo.GetAllCustomers();
        }

        //Store Operations
        public List<Store> GetAllStores()
        {
            return _custRepo.GetAllStores();
        }        
        public Store GetStoreById(int p_Id)
        {
            return _custRepo.GetStoreById(p_Id);
        }
        public List<Store> GetAllStoresWhithAddress()
        {
            return _custRepo.GetAllStoresWhithAddress();
        }

        //Address Operations
        public Address GetAddressById(int p_Id)
        {
            return _custRepo.GetAddressById(p_Id);
        }
        public List<Address> GetAllAddress()
        {
            return _custRepo.GetAllAddress();
        }

        //Product Opeartions
        public List<Product> GetAllProducts()
        {
            return _custRepo.GetAllProducts();
        }
        public List<Product> GetProductsByStoreId(int p_storeId)
        {
            return _custRepo.GetProductsByStoreId(p_storeId);
        }
        public Product GetProductById(int p_productId)
        {
            return _custRepo.GetProductById(p_productId);
        }
    }
}
