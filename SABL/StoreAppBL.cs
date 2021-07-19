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
        public Customer AddCustomer(Customer p_cust)
        {
            return (Customer)_custRepo.AddCustomer(p_cust);
        }

        public List<Customer> GetAllCustomer()
        {
            return _custRepo.GetAllCustomer();
        }

        public Customer FindCustomer(string p_searchKey)
        {
            return (Customer)_custRepo.FindCustomer(p_searchKey);
        }
    }
}
