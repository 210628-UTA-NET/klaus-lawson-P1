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

        public Customer AddCustomer(Customer p_customer)
        {
            return _custRepo.AddCustomer(p_customer);
        }
        public Customer FindCustomerByKey(string p_searchKey)
        {
            return _custRepo.FindCustomerByKey(p_searchKey);
        }
        public Customer FindCustomerLogin(string p_email, string p_pwd)
        {
            return _custRepo.FindCustomerLogin(p_email, p_pwd);
        }
        public Customer UpdateCustomer(Customer p_customer)
        {
            return _custRepo.UpdateCustomer(p_customer);
        }
        public bool DeleteCustomer(Customer p_cust)
        {
            return _custRepo.DeleteCustomer(p_cust);
        }
        public bool DeleteCustomerById(int p_id)
        {
            return _custRepo.DeleteCustomerById(p_id);
        }
        public List<Customer> GetAllCustomers()
        {
            return _custRepo.GetAllCustomers();
        }
        public List<Customer> GetAllCustomerWithAddress()
        {
            return _custRepo.GetAllCustomerWithAddress();
        }



        //Store Operations
        public Store AddStore(Store p_store)
        {
            return _custRepo.AddStore(p_store);
        }
        public Store UpdateStore(Store p_store)
        {
            return _custRepo.UpdateStore(p_store);
        }
        public bool DeleteStore(Store p_store)
        {
            return _custRepo.DeleteStore(p_store);
        }
        public bool DeleteStoreById(int p_id)
        {
            return _custRepo.DeleteStoreById(p_id);
        }
        public Store FindStoreByKey(string p_searchKey)
        {
            return _custRepo.FindStoreByKey(p_searchKey);
        }
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


        //Address Operation
        public Address AddAddress(Address p_address)
        {
            return _custRepo.AddAddress(p_address);
        }
        public Address UpdateAddress(Address p_address)
        {
            return _custRepo.UpdateAddress(p_address);
        }
        public bool DeleteAddressById(int p_id)
        {
            return _custRepo.DeleteAddressById(p_id);
        }
        public List<Address> GetAllAddress()
        {
            return _custRepo.GetAllAddress();
        }
        public Address GetAddressById(int p_Id)
        {
            return _custRepo.GetAddressById(p_Id);
        }


        //product Operations
        public Product AddProduct(Product p_product)
        {
            return _custRepo.AddProduct(p_product);
        }
        public Product UpdateProduct(Product p_product)
        {
            return _custRepo.UpdateProduct(p_product);
        }
        public bool DeleteProduct(Product p_product)
        {
            return _custRepo.DeleteProduct(p_product);
        }
        public bool DeleteProductById(int p_id)
        {
            return _custRepo.DeleteProductById(p_id);
        }
        public List<Product> GetAllProducts()
        {
            return _custRepo.GetAllProducts();
        }
        public List<Product> GetProductsByStoreId(int p_storeId)
        {
            return _custRepo.GetProductsByStoreId(p_storeId);
        }
        public List<Product> GetProductsByCategoryId(int p_categoryId)
        {
            return _custRepo.GetProductsByCategoryId(p_categoryId);
        }
        public Product GetProductById(int p_productId)
        {
            return _custRepo.GetProductById(p_productId);
        }



        //Order Operations
        public Order AddOrder(Order p_order)
        {
            return _custRepo.AddOrder(p_order);
        }
        public Order UpdateOrder(Order p_order)
        {
            return _custRepo.UpdateOrder(p_order);
        }
        public bool DeleteOrder(Order p_order)
        {
            return _custRepo.DeleteOrder(p_order);
        }
        public bool DeleteOrderById(int p_id)
        {
            return _custRepo.DeleteOrderById(p_id);
        }
        public List<Order> GetAllOrders()
        {
            return _custRepo.GetAllOrders();
        }
        public List<Order> GetOrdersByStoreId(int p_storeId)
        {
            return _custRepo.GetOrdersByStoreId(p_storeId);
        }
        public List<Order> GetOrdersByCustomerId(int p_customerId)
        {
            return _custRepo.GetOrdersByCustomerId(p_customerId);
        }
        public Order GetOrderById(int p_orderId)
        {
            return _custRepo.GetOrderById(p_orderId);
        }


        //LineItem Operations
        public LineItem AddLineItem(LineItem p_lineItem)
        {
            return _custRepo.AddLineItem(p_lineItem);
        }
        public LineItem UpdateLineItem(LineItem p_lineItem)
        {
            return _custRepo.UpdateLineItem(p_lineItem);
        }
        public bool DeleteLineItem(LineItem p_lineItem)
        {
            return _custRepo.DeleteLineItem(p_lineItem);
        }
        public bool DeleteLineItemByIds(int p_Oid, int p_Pid)
        {
            return _custRepo.DeleteLineItemByIds(p_Oid, p_Pid);
        }
        public List<LineItem> GetLineItemsByOrderId(int p_orderId)
        {
            return _custRepo.GetLineItemsByOrderId(p_orderId);
        }


        //Category Operations
        //product Operations
        public Category AddCategory(Category p_category)
        {
            return _custRepo.AddCategory(p_category);
        }
        public Category UpdateCategory(Category p_category)
        {
            return _custRepo.UpdateCategory(p_category);
        }
        public bool DeleteCategory(Category p_category)
        {
            return _custRepo.DeleteCategory(p_category);
        }
        public bool DeleteCategoryById(int p_id)
        {
            return _custRepo.DeleteCategoryById(p_id);
        }
        public List<Category> GetAllCategories()
        {
            return _custRepo.GetAllCategories();
        }
    }
}
