using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SACModels;

namespace SACBL
{
    /// <summary>
    /// Handles all the business logic for the restaurant model
    /// They are in charge of further processing/ sanitizing/ further validation of data
    /// Any logic that is used to access the data is for the DL, anything else will be in BL
    /// </summary>
    public interface ICustomerBL
    {
        /// <summary>
        /// Gets all the Customer from the database
        /// </summary>
        /// <returns>Returns a list of  Customers</returns>
        
        //Customer Operations
        List<Customer> GetAllCustomer();
        Customer AddCustomer(Customer p_cust);
        Customer FindCustomer(string p_searchKey);

        //StoreFront Operations
        StoreFront FindStoreFront(string storeNme);  
        public StoreFront FindStoreFrontByID(int p_stfID);      
        List<Product> GetStoreFrontProduct(string storeNme);

        //Product Operations
        Product FindProduct(int p_id);
        bool UpdateProduct(int id, Product Product);
        bool AddProduct (Product p_product);
        List<StoreFront> GetAllStoreFront();
         public bool AddNewOrder(Orders p_orders);
        int GetLastOrderId();
         bool AddLineItems(LineItems p_lineItems);
        List<Orders> GetOrderOfCustomer(int p_customerID);

    }
}
