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
        public Customer FindCustomerLogin(string p_email,string p_pwd)
        {
            return _context.Customers.Where(cust => cust.CustomerEmail == p_email && cust.CustomerPassword == p_pwd)
                                       .FirstOrDefault();
        }
        public Customer UpdateCustomer(Customer p_customer)
        {
            _context.Customers.Update(p_customer);
            _context.SaveChanges();
            return p_customer;
        }
        public bool DeleteCustomer(Customer p_cust)
        {
            if (p_cust != null)
            {
                _context.Customers.Remove(p_cust);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteCustomerById(int p_id)
        {
            var cust = _context.Customers.Where(c => c.Id ==p_id).FirstOrDefault();

            if (cust != null)
            {
                _context.Customers.Remove(cust);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }            
        }
        public List<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }
        public List<Customer> GetAllCustomerWithAddress()
        {
            return _context.Customers.Include("CustomerAddress").ToList();
        }
        


        //Store Operations
        public Store AddStore(Store p_store)
        {
            _context.Stores.Add(p_store);
            _context.SaveChanges();
            return p_store;
        }
        public Store UpdateStore(Store p_store)
        {
            _context.Stores.Update(p_store);
            _context.SaveChanges();
            return p_store;
        }
        public bool DeleteStore(Store p_store)
        {
            _context.Stores.Remove(p_store);
            _context.SaveChanges();
            return true;
        }
        public bool DeleteStoreById(int p_id)
        {
            var store = _context.Stores.Where(s => s.Id == p_id).FirstOrDefault();

            if (store != null)
            {
                _context.Stores.Remove(store);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public Store FindStoreByKey(string p_searchKey)
        {
            return _context.Stores.Where(store => store.StoreName
            .Contains(p_searchKey))
            .FirstOrDefault();
        }
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
        public Address AddAddress(Address p_address)
        {
            _context.Addresses.Add(p_address);
            _context.SaveChanges();
            return p_address;
        }
        public Address UpdateAddress(Address p_address)
        {
            _context.Addresses.Update(p_address);
            _context.SaveChanges();
            return p_address;
        }
        public bool DeleteAddress(Address p_address)
        {
            _context.Addresses.Remove(p_address);
            _context.SaveChanges();
            return true;
        }
        public bool DeleteAddressById(int p_id)
        {
            var address = _context.Addresses.Where(a => a.Id == p_id).FirstOrDefault();

            if (address != null)
            {
                _context.Addresses.Remove(address);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<Address> GetAllAddress()
        {
            return _context.Addresses.ToList();
        }
        public Address GetAddressById(int p_Id)
        {
            return _context.Addresses.Find(p_Id);
        }


        //product Operations
        public Product AddProduct(Product p_product)
        {
            _context.Products.Add(p_product);
            _context.SaveChanges();
            return p_product;
        }
        public Product UpdateProduct(Product p_product)
        {
            _context.Products.Update(p_product);
            _context.SaveChanges();
            return p_product;
        }
        public bool DeleteProduct(Product p_product)
        {
            _context.Products.Remove(p_product);
            _context.SaveChanges();
            return true;
        }
        public bool DeleteProductById(int p_id)
        {
            var product = _context.Products.Where(p => p.Id == p_id).FirstOrDefault();

            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }
        public List<Product> GetProductsByStoreId(int p_storeId)
        {
            return _context.Products.Select(prd => prd)
                .Where(prd => prd.StoreId == p_storeId)
                .ToList();
        }
        public List<Product> GetProductsByCategoryId(int p_categoryId)
        {
            return _context.Products.Select(prd => prd)
                .Where(prd => prd.CategoryId == p_categoryId)
                .ToList();
        }
        public Product GetProductById(int p_productId)
        {
            return _context.Products.Find(p_productId);
        }



        //Order Operations
        public Order AddOrder(Order p_order)
        {
            _context.Orders.Add(p_order);
            _context.SaveChanges();
            return p_order;
        }
        public Order UpdateOrder(Order p_order)
        {
            _context.Orders.Update(p_order);
            _context.SaveChanges();
            return p_order;
        }
        public bool DeleteOrder(Order p_order)
        {
            _context.Orders.Remove(p_order);
            _context.SaveChanges();
            return true;
        }
        public bool DeleteOrderById(int p_id)
        {
            var order = _context.Orders.Where(o => o.Id == p_id).FirstOrDefault();

            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<Order> GetAllOrders()
        {
            return _context.Orders.ToList();
        }
        public List<Order> GetOrdersByStoreId(int p_storeId)
        {
            return _context.Orders.Where(o => o.StoreId == p_storeId)
                .ToList();
        }
        public List<Order> GetOrdersByCustomerId(int p_customerId)
        {
            return _context.Orders.Where(o => o.CustomerId == p_customerId)
                .ToList();
        }
        public Order GetOrderById(int p_orderId)
        {
            return _context.Orders.Find(p_orderId);
        }


        //LineItem Operations
        public LineItem AddLineItem(LineItem p_lineItem)
        {
            _context.lineItems.Add(p_lineItem);
            _context.SaveChanges();
            return p_lineItem;
        }
        public LineItem UpdateLineItem(LineItem p_lineItem)
        {
            _context.lineItems.Update(p_lineItem);
            _context.SaveChanges();
            return p_lineItem;
        }
        public bool DeleteLineItem(LineItem p_lineItem)
        {
            _context.lineItems.Remove(p_lineItem);
            _context.SaveChanges();
            return true;
        }
        public bool DeleteLineItemByIds(int p_Oid,int p_Pid)
        {
            var lineItem = _context.lineItems.Where(li => li.OrderId == p_Oid && li.ProductId == p_Pid).FirstOrDefault();

            if (lineItem != null)
            {
                _context.lineItems.Remove(lineItem);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<LineItem> GetLineItemsByOrderId(int p_orderId)
        {
            return _context.lineItems.Where(li => li.OrderId == p_orderId)
                .ToList();
        }


        //Category Operations
        //product Operations
        public Category AddCategory(Category p_category)
        {
            _context.categories.Add(p_category);
            _context.SaveChanges();
            return p_category;
        }
        public Category UpdateCategory(Category p_category)
        {
            _context.categories.Update(p_category);
            _context.SaveChanges();
            return p_category;
        }
        public bool DeleteCategory(Category p_category)
        {
            _context.categories.Remove(p_category);
            _context.SaveChanges();
            return true;
        }
        public bool DeleteCategoryById(int p_id)
        {
            var category= _context.categories.Where(c => c.Id == p_id).FirstOrDefault();

            if (category != null)
            {
                _context.categories.Remove(category);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<Category> GetAllCategories()
        {
            return _context.categories.ToList();
        }
    }
}
