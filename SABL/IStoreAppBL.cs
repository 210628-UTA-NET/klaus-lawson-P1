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
        List<Customer> GetAllCustomer();
        Customer AddCustomer(Customer p_cust);
        Customer FindCustomer(string p_searchKey);
    }
}
