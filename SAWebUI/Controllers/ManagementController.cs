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
    [Authorize(Roles ="Admin")]
    public class ManagementController : Controller
    {
        private IStoreAppBL _storeBL;

        // constructor
        public ManagementController(IStoreAppBL p_storeBL)
        {
            _storeBL = p_storeBL;
        }
        








        //private method
        private void populateState()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\klaus\Documents\Revature\SAP1\SAWebUI\Files\states.txt");
            List<string> states = new List<string>();
            foreach (string line in lines)
            {
                states.Add(line);
            }
            ViewBag.States = new SelectList(states);
        }
        private void populateStore()
        {
            List<StoreVM> allStore = _storeBL.GetAllStoresWhithAddress().Select(store => new StoreVM(store)).ToList();
            ViewBag.Stores = new SelectList(allStore, "Id", "StoreName");
        }
        private void populateCategory()
        {
            List<CategoryVM> allCategories = _storeBL.GetAllCategories().Select(cat => new CategoryVM(cat)).ToList();
            ViewBag.Categories = new SelectList(allCategories, "Id", "CategoryName");
        }























        //customer management
        public IActionResult CustomerManagement(string SearchName)
        {
            if (!string.IsNullOrEmpty(SearchName))
            {
                List<CustomerVM> custByNameVM = new List<CustomerVM>();
                List<Customer> custByName = _storeBL.FindCustomerByName(SearchName);
                foreach (Customer c in custByName)
                {
                    custByNameVM.Add(new CustomerVM(c));
                }
                return View(nameof(CustomerManagement), custByNameVM);
            }
            else
            {
                return View(
                _storeBL.GetAllCustomerWithAddress()
                .Select(cust => new CustomerVM(cust))
                .ToList()
                );
            }
            
        }
        public IActionResult CreateCustomer()
        {
            populateState();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
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
                return View(p_customerVM);
            }
        }

        //edit store no view yet
        public IActionResult EditCustomer(int p_custId)
        {
            if (p_custId == 0)
            {
                return NotFound();
            }
            CustomerVM custUpdateVM = new CustomerVM(_storeBL.GetCustomerWithAddressById(p_custId));
            if (custUpdateVM == null)
            {
                return NotFound();
            }
            populateState();
            return View(custUpdateVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCustomer(CustomerVM custUpdateVM)
        {
            Customer custUpdate = custUpdateVM.ConvertToCustomer();
            AddressVM avm = custUpdateVM.addressVM;
            Address custAddrUpdate = avm.ConvertToAddress();
            if (ModelState.IsValid)
            {
                _storeBL.UpdateCustomer(custUpdate);
                _storeBL.UpdateAddress(custAddrUpdate);
                return RedirectToAction(nameof(StoreManagement));
            }
            populateState();
            return View(new CustomerVM(custUpdate));
        }

        //delete store no view yet
        public IActionResult DeleteCustomer(int p_customerId)
        {
            if (p_customerId == 0)
            {
                return NotFound();
            }
            CustomerVM custDeleteVM = new CustomerVM(_storeBL.GetCustomerWithAddressById(p_customerId));
            if (custDeleteVM == null)
            {
                return NotFound();
            }
            populateState();
            return View(custDeleteVM);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCustomerPost(int Id)
        {
            Customer custDelete = _storeBL.FindCustomerById(Id);
            if (custDelete == null)
            {
                return NotFound();
            }
            _storeBL.DeleteCustomer(custDelete);
            _storeBL.DeleteAddressById(custDelete.CustomerAddressId);
            return RedirectToAction(nameof(CustomerManagement));
        }

        























        // Store Management
        public IActionResult StoreManagement()
        {
            return View(_storeBL.GetAllStoresWhithAddress()
                .Select(store => new StoreVM(store))
                .ToList());
        }
        
        //create Store
        public IActionResult CreateStore() 
        {
            populateState();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        //edit store
        public IActionResult EditStore(int p_storeId)
        {
            if (p_storeId == 0)
            {
                return NotFound();
            }            
            StoreVM strUpdateVM = new StoreVM(_storeBL.GetStoreWithAddressById(p_storeId));
            if (strUpdateVM == null)
            {
                return NotFound();
            }
            populateState();
            return View(strUpdateVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditStore(StoreVM strUpdateVM)
        {
            Store strUpdate = strUpdateVM.ConvertToStore();
            AddressVM avm = strUpdateVM.addressVM;
            Address strAddrUpdate = avm.ConvertToAddress();
            if (ModelState.IsValid)
            {
                _storeBL.UpdateStore(strUpdate);
                _storeBL.UpdateAddress(strAddrUpdate);
                return RedirectToAction(nameof(StoreManagement));
            }
            populateState();
            return View(new StoreVM(strUpdate));
        }

        //delete store
        public IActionResult DeleteStore(int p_storeId)
        {
            if (p_storeId == 0)
            {
                return NotFound();
            }
            StoreVM strDeleteVM = new StoreVM(_storeBL.GetStoreWithAddressById(p_storeId));
            if (strDeleteVM == null)
            {
                return NotFound();
            }
            populateState();
            return View(strDeleteVM);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteStorePost(int Id)
        {
             Store strDelete = _storeBL.GetStoreById(Id);
            if (strDelete == null)
            {
                return NotFound();
            }
            _storeBL.DeleteStore(strDelete);
            _storeBL.DeleteAddressById(strDelete.StoreAddressId);
            return RedirectToAction(nameof(StoreManagement));
        }

        //View Store Order history

        public IActionResult ViewStoreOrderHistory(int p_storeId)
        {
            List<OrderVM> o = _storeBL.GetOrdersByStoreId(p_storeId)
                .Select(order => new OrderVM(order))
                .ToList();
            //return RedirectToAction("MyOrders", "OurStore", o);
            return View(o);
        }
        public IActionResult ViewStoreProducts(int p_storeId)
        {
            return View(_storeBL.GetProductsByStoreId(p_storeId)
                .Select(prd => new ProductVM(prd))
                .ToList());
        }

























        //Product Management
        public IActionResult ProductManagement()
        {
            return View(_storeBL.GetAllProducts()
                .Select(prd => new ProductVM(prd))
                .ToList());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ProductManagement(int p_Storeid)
        {
            if (p_Storeid == 0)
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

        // create Product
        public IActionResult CreateProduct()
        {
            populateStore();
            populateCategory();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateProduct(ProductVM p_productVM)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    Product newProduct = p_productVM.ConvertToProduct();
                    _storeBL.AddProduct(newProduct);
                    return RedirectToAction(nameof(ProductManagement));
                }
                populateStore();
                populateCategory();
                return View(p_productVM);
            }
            catch (Exception)
            {
                populateStore();
                populateCategory();
                return View(p_productVM);
            }
        }

        //edit product
        public IActionResult EditProduct(int p_productId)
        {
            if (p_productId == 0)
            {
                return NotFound();
            }
            ProductVM prdUpdateVM = new ProductVM(_storeBL.GetProductById(p_productId));
            if (prdUpdateVM == null)
            {
                return NotFound();
            }
            populateStore();
            populateCategory();
            return View(prdUpdateVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditProduct(ProductVM prdUpdateVM)
        {
           Product prdUpdate = prdUpdateVM.ConvertToProduct();
            if (ModelState.IsValid)
            {
                _storeBL.UpdateProduct(prdUpdate);
                return RedirectToAction(nameof(ProductManagement));
            }
            populateStore();
            populateCategory();
            return View(new ProductVM(prdUpdate));
        }

        //delete product
        public IActionResult DeleteProduct(int p_productId)
        {
            ProductVM prdDeleteVM = new ProductVM(_storeBL.GetProductById(p_productId));
            if (prdDeleteVM == null)
            {
                return NotFound();
            }
            populateStore();
            populateCategory();
            return View(prdDeleteVM);
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken] 
        public IActionResult DeleteProductPost(int Id)
        {
            var prdDelete = _storeBL.GetProductById(Id);
            if(prdDelete == null)
            {
                return NotFound();
            }
            _storeBL.DeleteProduct(prdDelete);
            return RedirectToAction(nameof(ProductManagement));
        }

    }
}
