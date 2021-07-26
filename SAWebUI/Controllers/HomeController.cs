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

        [HttpPost("login")]
        public async Task<IActionResult> ValidateAsync(string email, string password, string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            Customer loginCust = _storeBL.FindCustomerLogin(email, password);
            
            if (loginCust!=null)
            {
                TempData["UserId"] = loginCust.Id;
                SessionHelper.SetObjectAsJson(HttpContext.Session, "User", loginCust);
                var claims = new List<Claim>();
                claims.Add(new Claim("email", email));
                claims.Add(new Claim(ClaimTypes.Sid,loginCust.Id.ToString()));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, email));
                claims.Add(new Claim(ClaimTypes.MobilePhone, loginCust.CustomerPhone));
                claims.Add(new Claim(ClaimTypes.Name, loginCust.CustomerFirstName+loginCust.CustomerLastName));
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
        public IActionResult MyProfile()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}