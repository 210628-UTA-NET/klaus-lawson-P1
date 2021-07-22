 using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SABL;
using SAModels;
using SAWebUI.Models;
using Microsoft.AspNetCore.Authorization;

namespace SAWebUI.Controllers
{
    public class CustomerController : Controller
    {
        private IStoreAppBL _storeBL;
        public CustomerController(IStoreAppBL p_storeBL)
        {
            _storeBL = p_storeBL;
        }
        
        public IActionResult Index()
        {
            return View(
                _storeBL.GetAllCustomers()
                .Select(cust => new CustomerVM(cust))
                .ToList()
                );
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CustomerVM p_customerVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _storeBL.AddCustomer(new Customer
                    {
                        CustomerFirstName = p_customerVM.CustomerFirstName,
                        CustomerLastName = p_customerVM.CustomerLastName,
                        CustomerEmail = p_customerVM.CustomerEmail,
                        CustomerPhone = p_customerVM.CustomerPhone,
                        CustomerPassword = p_customerVM.CustomerPassword,
                        CustomerAddressId = p_customerVM.CustomerAddressId
                    });
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception)
            {
                return View();
            }
            return View();
        }
    }
}
