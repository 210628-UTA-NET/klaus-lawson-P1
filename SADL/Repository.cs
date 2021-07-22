using Microsoft.EntityFrameworkCore;
using SAModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADL
{
    public class Repository:IRepository
    {
        private SADBContext _context;

        //Repository Constructor 
        public Repository(SADBContext p_context)
        {
            _context = p_context;
        }

        //Customer Operation
        public Customer AddCustomer(Customer p_customer)
        {
            _context.Customers.Add(p_customer);
            _context.SaveChanges();
            return p_customer;
        }
        public Customer FindCustomerByKey(string p_searchKey)
        {
            return _context.Customers.Where(cust => cust.CustomerEmail == p_searchKey)
                                       .FirstOrDefault();
        }
        public Customer UpdateCustomerById(int p_id)
        {
            throw new System.NotImplementedException();
        }
        public bool DeleteCustomerById(int p_id)
        {
            throw new NotImplementedException();
        }
        public bool DeleteCustomer(Customer p_cust)
        {
            _context.Customers.Remove(p_cust);
            return true;
        }
        public List<Customer> GetAllCustomers()
        {
            return _context.Customers.Select(cust => cust).ToList();
        }

        
        //Store Operations
        public List<Store> GetAllStores()
        {
            return _context.Stores.ToList();
        }        
        public Store GetStoreById(int p_Id)
        {
            return _context.Stores.Find(p_Id);
        }
        public List<Store> GetAllStoresWhithAddress()
        {
            return _context.Stores.Include("StoreAddress").ToList();
        }


        //Address Operation
        public List<Address> GetAllAddress()
        {
            return _context.Addresses.ToList();
        }
        public Address GetAddressById(int p_Id)
        {
            return _context.Addresses.Find(p_Id);
        }

        //product Operations
        public List<Product> GetAllProducts()
        {
            return _context.Products.Select(prd => prd).ToList();
        }

        public List<Product> GetProductsByStoreId(int p_storeId)
        {
            return _context.Products.Select(prd => prd)
                .Where(prd => prd.StoreId == p_storeId)
                .ToList();
        }
        public Product GetProductById(int p_productId)
        {
            return _context.Products.Find(p_productId);
        }

        //Order Operations


    }
}
