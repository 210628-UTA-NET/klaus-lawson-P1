using SAModels;
using System;
using System.Collections.Generic;

namespace SABL
{
    public interface IStoreAppBL
    {
        public Customer AddCustomer(Customer p_customer);
        public Customer FindCustomerByKey(string p_searchKey);
        public Customer FindCustomerLogin(string p_email, string p_pwd);
        public Customer UpdateCustomer(Customer p_customer);
        public bool DeleteCustomer(Customer p_cust);
        public bool DeleteCustomerById(int p_id);
        public List<Customer> GetAllCustomers();
        public List<Customer> GetAllCustomerWithAddress();



        //Store Operations
        public Store AddStore(Store p_store);
        public Store UpdateStore(Store p_store);
        public bool DeleteStore(Store p_store);
        public bool DeleteStoreById(int p_id);
        public Store FindStoreByKey(string p_searchKey);
        public List<Store> GetAllStores();
        public Store GetStoreById(int p_Id);
        public List<Store> GetAllStoresWhithAddress();


        //Address Operation
        public Address AddAddress(Address p_address);
        public Address UpdateAddress(Address p_address);
        public bool DeleteAddressById(int p_id);
        public List<Address> GetAllAddress();
        public Address GetAddressById(int p_Id);


        //product Operations
        public Product AddProduct(Product p_product);
        public Product UpdateProduct(Product p_product);
        public bool DeleteProduct(Product p_product);
        public bool DeleteProductById(int p_id);
        public List<Product> GetAllProducts();
        public List<Product> GetProductsByStoreId(int p_storeId);
        public List<Product> GetProductsByCategoryId(int p_categoryId);
        public Product GetProductById(int p_productId);



        //Order Operations
        public Order AddOrder(Order p_order);
        public Order UpdateOrder(Order p_order);
        public bool DeleteOrder(Order p_order);
        public bool DeleteOrderById(int p_id);
        public List<Order> GetAllOrders();
        public List<Order> GetOrdersByStoreId(int p_storeId);
        public List<Order> GetOrdersByCustomerId(int p_customerId);
        public Order GetOrderById(int p_orderId);


        //LineItem Operations
        public LineItem AddLineItem(LineItem p_lineItem);
        public LineItem UpdateLineItem(LineItem p_lineItem);
        public bool DeleteLineItem(LineItem p_lineItem);
        public bool DeleteLineItemByIds(int p_Oid, int p_Pid);
        public List<LineItem> GetLineItemsByOrderId(int p_orderId);


        //Category Operations
        //product Operations
        public Category AddCategory(Category p_category);
        public Category UpdateCategory(Category p_category);
        public bool DeleteCategory(Category p_category);
        public bool DeleteCategoryById(int p_id);
        public List<Category> GetAllCategories();
    }
}
