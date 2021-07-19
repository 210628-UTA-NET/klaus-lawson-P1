using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SABL;
using SAModels;
using SAWebUI.Models;

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
                _storeBL.GetAllCustomer()
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
                        Name = p_customerVM.Name,
                        Address = p_customerVM.Address,
                        Email = p_customerVM.Email,
                        Phone = p_customerVM.Phone
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
