using System;
using System.Collections.Generic;
using SACModels;
using SACDL;

namespace SACBL
{
    public class CustomerBL : ICustomerBL
    {
        private Repository _custRepo;
        public CustomerBL(Repository p_custRepo)
        {
            _custRepo = p_custRepo;
        }
       
        public Customer AddCustomer(Customer p_cust)
        {
            return (Customer)_custRepo.AddCustomer(p_cust);
        }

        public List<Customer> GetAllCustomer()
        {
            return _custRepo.GetAllCustomer();
        }

        public Customer FindCustomer(string p_searchKey){
            return (Customer)_custRepo.FindCustomer(p_searchKey);
        }
      
        public StoreFront FindStoreFront(string storeNme){
            return (StoreFront)_custRepo.FindStoreFront(storeNme);
        }
        public StoreFront FindStoreFrontByID(int p_stfID){
             return (StoreFront)_custRepo.FindStoreFrontByID(p_stfID);
        }
        public List<StoreFront> GetAllStoreFront(){
             return (List<StoreFront>)_custRepo.GetAllStoreFront();
        }
        public List<Product> GetStoreFrontProduct(string storeNme){
            return (List<Product>) _custRepo.GetStoreFrontProducts(storeNme);
        }
       
        public Product FindProduct(int p_id){
            return (Product) _custRepo.FindProduct(p_id);
        }

        public bool UpdateProduct(int id, Product Product){
            return  _custRepo.UpdateProduct(id,Product);
        }
        public bool AddProduct (Product p_product){ 
            return  _custRepo.AddProduct(p_product);
        }
         public bool AddNewOrder(Orders p_orders){
             return _custRepo.AddNewOrder(p_orders);
         }
        public int GetLastOrderId(){
            return _custRepo.GetLastOrderId();
        }
        public bool AddLineItems(LineItems p_lineItems){
            return _custRepo.AddLineItems(p_lineItems);
        }
        public List<Orders> GetOrderOfCustomer(int p_customerID){
            return _custRepo.GetOrderOfCustomer(p_customerID);
        }
    }

}
