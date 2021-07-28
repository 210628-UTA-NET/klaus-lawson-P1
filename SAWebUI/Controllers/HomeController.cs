using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SABL;
using SAModels;
using SAWebUI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using SAWebUI.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SAWebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IStoreAppBL _storeBL;

        public HomeController(ILogger<HomeController> logger, IStoreAppBL p_storeBL)
        {
            _logger = logger;
            _storeBL = p_storeBL;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("login")]
        public IActionResult Login(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpGet("denied")]
        public IActionResult Denied()
        {
            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> ValidateAsync(string email, string password, string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            Customer loginCust = _storeBL.FindCustomerLogin(email, password);
            
            if (loginCust!=null)
            {
                TempData["UserId"] = loginCust.Id;
                SessionHelper.SetObjectAsJson(HttpContext.Session, "User", loginCust);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "Id", loginCust.Id);
                var claims = new List<Claim>();
                claims.Add(new Claim("email", email));
                claims.Add(new Claim("Id", loginCust.Id.ToString()));
                claims.Add(new Claim(ClaimTypes.Sid,loginCust.Id.ToString()));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, email));
                claims.Add(new Claim(ClaimTypes.MobilePhone, loginCust.CustomerPhone));
                claims.Add(new Claim(ClaimTypes.Name, loginCust.CustomerFirstName+loginCust.CustomerLastName));
                claims.Add(new Claim(ClaimTypes.Role, loginCust.CustomerRole));
                
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsprincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(claimsprincipal);
                if (!string.IsNullOrEmpty(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return Redirect("/");
                }
                
            }
            TempData["Error"] = "Error. Email or Password is invalid";
            return View("Login");
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
        //Get register
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
        public IActionResult Register()
        {
            populateState();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(CustomerVM p_customerVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Customer newCust = p_customerVM.ConvertToCustomer();
                    newCust.CustomerRole = "User";
                    Address newaddress = p_customerVM.addressVM.ConvertToAddress();

                    newCust.CustomerAddressId = _storeBL.AddAddress(newaddress).Id;
                    _storeBL.AddCustomer(newCust);
                    return RedirectToAction(nameof(Login));
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
        public IActionResult MyProfile()
        {
            _logger.LogInformation("My Profile Page");
            try
            {
                throw new Exception();
            }catch(Exception ex)
            {
                _logger.LogError(ex, "This Exception from Profile Page");
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}