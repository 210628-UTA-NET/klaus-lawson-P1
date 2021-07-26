﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SABL;
using SAModels;
using SAWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SAWebUI.Helpers;
using Microsoft.AspNetCore.Http;

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

        //Get all product from all store
        public IActionResult Shopping()
        {
            if (SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart") != null)
            {
                List<Cart> li2 = SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart");
                double x = 0;
                foreach (var item in li2)
                {
                    x += item.Bill;
                }
                TempData["Total"] = x;
                SessionHelper.SetObjectAsJson(HttpContext.Session, "Total", x);
            }
            List<ProductVM> ListProductsVM = _storeBL.GetAllProducts().Select(prd => new ProductVM(prd)).ToList();
            return View(ListProductsVM);
        }



        public ActionResult AddToCart(int p_id)
        {
            ProductVM p = new ProductVM(_storeBL.GetProductById(p_id));
            return View(p);
        }
        List<Cart> li = new List<Cart>();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddToCart(ProductVM pi, string qty, int p_id)
        {

            ProductVM p = new ProductVM(_storeBL.GetProductById(p_id));
            TempData["StoreId"] = p.StoreId;
            Cart c = new Cart();
            c.Productid = p.Id;
            c.Price = (double)p.ProductUnitPrice;
            c.Qty = Convert.ToInt32(qty);
            c.Bill = c.Price * c.Qty;
            c.Productname = p.ProductName;
            if (SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart") == null)
            {
                li.Add(c);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", li);
            }
            else
            {
                TempData.TryGetValue("cart", out object o);
                List<Cart> li2 = SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart");

                int flag = 0;
                foreach (var item in li2)
                {
                    if (item.Productid == c.Productid)
                    {
                        item.Qty += c.Qty;
                        item.Bill += c.Bill;
                        flag = 1;
                    }
                }
                if (flag == 0)
                {
                    li2.Add(c);
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", li2);
            }
            TempData.Keep();
            return RedirectToAction("Shopping");
        }

        public ActionResult Checkout()
        {
            List<Cart> l = SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart");
            TempData.Keep();
            return View(l);
        }

        OrderVM orderVM;
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Checkout(int? i)
        {
            List<Cart> li = SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart");
            orderVM = new OrderVM();
            orderVM.Location = "Store KL";
            orderVM.OrderDate = DateTime.Now;
            orderVM.CustomerId = (int)SessionHelper.GetObjectFromJson<Customer>(HttpContext.Session, "User").Id;

            orderVM.OrderTotalPrice = (double)(SessionHelper.GetObjectFromJson<double>(HttpContext.Session, "Total"));
            orderVM.OrderStatus = "PLACED";
            orderVM.StoreId = (int)(TempData["StoreId"]);

            int ordId = _storeBL.AddOrder(orderVM.ConvertToOrder()).Id;
            foreach (var item in li)
            {
                LineItem lineItem = new LineItem
                {
                    ProductId = item.Productid,
                    OrderId = ordId,
                    QuantityToBuy = item.Qty
                };
                _storeBL.AddLineItem(lineItem);
            }
            TempData.Remove("total");
            SessionHelper.SetObjectAsJson(HttpContext.Session, "Total", 0);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", null);
            TempData["msg"] = "Transaction has been completed";
            TempData.Keep();
            return RedirectToAction("Shopping");
        }

        [HttpPost]
        public ActionResult Remove(int? id)
        {
            li = SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart");
            Cart c = li.Where(x => x.Productid == id).SingleOrDefault();
            li.Remove(c);

            double h = 0;
            foreach (var item in li)
            {
                h += item.Bill;
            }
            TempData.Remove("total");
            TempData["total"] = h;
            SessionHelper.SetObjectAsJson(HttpContext.Session, "Total", h);
            //TempData.Keep();
            return RedirectToAction("Checkout");
        }
    }
}
