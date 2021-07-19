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

        public Customer FindCustomer(string p_searchKey)
        {
            return _context.Customers.Where(cust => cust.Name == p_searchKey)
                                       .FirstOrDefault();
        }
        public bool DeleteCustomer(Customer p_cust)
        {
            _context.Customers.Remove(p_cust);
            return true;
        }

        public Customer UpdateCustomer(int p_id)
        {
            throw new System.NotImplementedException();
        }

        public List<Customer> GetAllCustomer()
        {
            return _context.Customers.Select(cust => cust).ToList();
        }

        public Customer DeleteCustomer(int p_id)
        {
            throw new NotImplementedException();
        }
    }
}
