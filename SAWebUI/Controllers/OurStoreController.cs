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
    public class OurStoreController : Controller
    {
        private IStoreAppBL _storeBL;
        private List<ProductVM> _myCart;
        public OurStoreController(IStoreAppBL p_storeBL)
        {
            _storeBL = p_storeBL;
            _myCart = new List<ProductVM>();
        }
        public IActionResult OurStoreIndex()
        {
            List<Store> lstores = _storeBL.GetAllStoresWhithAddress();
            List<StoreVM> listStoreVM = new List<StoreVM>();
            /*var listStoreAddr = _storeBL.GetAllStores().Join(_storeBL.GetAllAddress(),
                                store => store.StoreAddressId,
                                addr => addr.Id,
                                (store, addr) => new { Store = store, Address = addr }).ToList();*/
            /*foreach (var sa in listStoreAddr)
            {
                StoreVM storeVM = new StoreVM();
                storeVM.Id = sa.Store.Id;
                storeVM.StoreName = sa.Store.StoreName;
                storeVM.StorePhone = sa.Store.StorePhone;
                storeVM.StoreAddressId = sa.Store.StoreAddressId;
                storeVM.Street = sa.Address.Street;
                storeVM.City = sa.Address.City;
                storeVM.State = sa.Address.State;
                storeVM.Country = sa.Address.Country;
                listStoreVM.Add(storeVM);
            }
            return View(listStoreVM);*/
            foreach (var sa in lstores)
            {
                StoreVM storeVM = new StoreVM();
                storeVM.Id = sa.Id;
                storeVM.StoreName = sa.StoreName;
                storeVM.StorePhone = sa.StorePhone;
                storeVM.StoreAddressId = sa.StoreAddressId;
                storeVM.Street = sa.StoreAddress.Street;
                storeVM.City = sa.StoreAddress.City;
                storeVM.State = sa.StoreAddress.State;
                storeVM.Country = sa.StoreAddress.Country;
                listStoreVM.Add(storeVM);
            }
            return View(listStoreVM);

        }

        public IActionResult ViewStore(int p_id)
        {
            /*Store st = _storeBL.GetStoreById(p_id);
            Address ad = _storeBL.GetAddressById(st.StoreAddressId);
            StoreVM storeVM = new StoreVM(st,ad);*/
            ViewBag.StoreName = _storeBL.GetStoreById(p_id).StoreName;
            List<ProductVM> storeVMProducts = new List<ProductVM>();
            List<Product> storeProducts =  _storeBL.GetProductsByStoreId(p_id);
            foreach(Product p in storeProducts)
            {
                storeVMProducts.Add(new ProductVM(p));
            }
            return View(storeVMProducts);
        }
        public IActionResult MyCart(int p_productId)
        {
            var cart = new List<LineItemVM>();
            return View(_myCart);
        }
    }
}
