using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SABL;
using SAModels;
using SAWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAWebUI.Controllers
{
    [Authorize]
    public class OurStoreController : Controller
    {
        private IStoreAppBL _storeBL;
        public OurStoreController(IStoreAppBL p_storeBL)
        {
            _storeBL = p_storeBL;
        }

        // Get All Store
        public IActionResult OurStoreIndex()
        {
            List<Store> lstores = _storeBL.GetAllStoresWhithAddress();
            List<StoreVM> listStoreVM = new List<StoreVM>();
            /*List<Store> lstores  = _storeBL.GetAllStores().Join(_storeBL.GetAllAddress(),
                                store => store.StoreAddressId,
                                addr => addr.Id,
                                (store, addr) => new { Store = store, Address = addr }).ToList();*/
            foreach (var sa in lstores)
            {
                StoreVM storeVM = new StoreVM(sa);
                listStoreVM.Add(storeVM);
            }
            return View(listStoreVM);
        }

        //Get all Products from a store
        public IActionResult ViewStoreProducts(int p_Storeid)
        {
            ViewBag.StoreName = _storeBL.GetStoreById(p_Storeid).StoreName;
            List<ProductVM> storeVMProducts = new List<ProductVM>();
            List<Product> storeProducts =  _storeBL.GetProductsByStoreId(p_Storeid);
            foreach(Product p in storeProducts)
            {
                storeVMProducts.Add(new ProductVM(p));
            }
            return View(storeVMProducts);
        }
        //Get all product from all store
        public IActionResult ViewAllProducts()
        {
            
            List<ProductVM> ListProductsVM = new List<ProductVM>();
            List<Product> AllProducts = _storeBL.GetAllProducts();
            foreach (Product p in AllProducts)
            {
                ListProductsVM.Add(new ProductVM(p));
            }
            return View(ListProductsVM);
        }


        public IActionResult AddtoCart(int p_productId)
        {
            Product p = _storeBL.GetProductById(p_productId);
            
            int stId = p.StoreId;
            if (ViewData["Cart"] == null)
            {
                List<LineItemVM> cart = new List<LineItemVM>();
                LineItem li = new LineItem();
                li.ProductId = p_productId;
                li.QuantityToBuy = 1;
                cart.Add(new LineItemVM(li));
                ViewData["Cart"] = cart;
            }
            else
            {
                List<LineItemVM> cart = (List<LineItemVM>)ViewBag.Cart;
                LineItem li = new LineItem();
                li.ProductId = p_productId;
                li.QuantityToBuy = 1;
                cart.Add(new LineItemVM(li));
                ViewData["Cart"] = cart;
            }

            return RedirectToAction("ViewStore", new { p_id = stId});
        }
    }
}
