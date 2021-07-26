 using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SABL;
using SAModels;
using SAWebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SAWebUI.Controllers
{
    [Authorize]
    public class ManagementController : Controller
    {
        private IStoreAppBL _storeBL;
        public ManagementController(IStoreAppBL p_storeBL)
        {
            _storeBL = p_storeBL;
        }
        
        //Management index
        public IActionResult ManagementIndex()
        {
            return View();
        }

        //customer management
        public IActionResult CustomerManagement()
        {
            return View(
                _storeBL.GetAllCustomerWithAddress()
                .Select(cust => new CustomerVM(cust))
                .ToList()
                );
        }
       // Store Management
        public IActionResult StoreManagement()
        {
            return View(_storeBL.GetAllStoresWhithAddress()
                .Select(store=> new StoreVM(store))
                .ToList());
        }
        //Inventory Management
        [HttpGet]
        public IActionResult InventoryManagement()
        {
            return View(_storeBL.GetAllProducts()
                .Select(prd => new ProductVM(prd))
                .ToList());
        }
        [HttpPost]
        public IActionResult InventoryManagement(int p_Storeid)
        {
            if(p_Storeid == 0)
            {
                return Redirect("InventoryManagement");
            }
            else
            {
                ViewBag.StoreName = _storeBL.GetStoreById(p_Storeid).StoreName;
                List<ProductVM> storeVMProducts = new List<ProductVM>();
                List<Product> storeProducts = _storeBL.GetProductsByStoreId(p_Storeid);
                foreach (Product p in storeProducts)
                {
                    storeVMProducts.Add(new ProductVM(p));
                }
                return View(storeVMProducts);
            }
            
        }

        // Creation Operations
        private void populateState()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\klaus\Documents\Revature\SAP1\SAWebUI\Files\states.txt");
            List<string> states = new List<string>();
            foreach (string line in lines)
            {
                states.Add(line);
            }
            ViewBag.States =new SelectList(states);
        }
        private void populateStore()
        {
            List<StoreVM> allStore = _storeBL.GetAllStoresWhithAddress().Select(store => new StoreVM(store)).ToList();
            ViewBag.Stores = new SelectList(allStore,"Id","StoreName");
        }
        private void populateCategory()
        {
            List<CategoryVM> allCategories = _storeBL.GetAllCategories().Select(cat=> new CategoryVM(cat)).ToList();
            ViewBag.Categories = new SelectList(allCategories,"Id","CategoryName");
        }
        public IActionResult CreateCustomer()
        {
            populateState();
            return View();
        }
        [HttpPost]
        public IActionResult CreateCustomer(CustomerVM p_customerVM)
        {            
            try
            {
                if (ModelState.IsValid)
                {
                    Customer newCust = p_customerVM.ConvertToCustomer();
                    Address newaddress = p_customerVM.addressVM.ConvertToAddress();
                   
                    newCust.CustomerAddressId = _storeBL.AddAddress(newaddress).Id;
                    _storeBL.AddCustomer(newCust);
                    return RedirectToAction(nameof(CustomerManagement));
                }
                populateState();
                return View();
            }
            catch (Exception)
            {
                populateState();
                return View();
            }
        }

        public IActionResult CreateStore() 
        {
            populateState();
            return View();
        }
        [HttpPost]
        public IActionResult CreateStore(StoreVM p_storeVM) 
        {

            try
            {
                if (ModelState.IsValid)
                {
                    Store newStore = p_storeVM.ConvertToStore();
                    Address newaddress = p_storeVM.addressVM.ConvertToAddress();

                    newStore.StoreAddressId = _storeBL.AddAddress(newaddress).Id;
                    _storeBL.AddStore(newStore);
                    return RedirectToAction(nameof(StoreManagement));
                }
                populateState();
                return View();
            }
            catch (Exception)
            {
                populateState();
                return View();
            }
        }

        public IActionResult CreateProduct()
        {
            populateStore();
            populateCategory();
            return View();
        }
        [HttpPost]
        public IActionResult CreateProduct(ProductVM p_productVM)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    Product newProduct = p_productVM.ConvertToProduct();
                    _storeBL.AddProduct(newProduct);
                    return RedirectToAction(nameof(InventoryManagement));
                }
                populateStore();
                populateCategory();
                return View();
            }
            catch (Exception)
            {
                populateStore();
                populateCategory();
                return View();
            }
        }
    }
}
