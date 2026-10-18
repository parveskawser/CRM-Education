using CRM.Entities;
using CRM.Facade.Interface;
using CRM.Framework;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Linq;

namespace CRM.Web.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserFacade _userFacade;
        public AccountController(IUserFacade userFacade)
        {
            _userFacade = userFacade;
        }

        [Route(UrlRewrite.Account.Login)]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route(UrlRewrite.Account.Login)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(
            User user,
            bool rememberMe = false)
        {
            //Get User and pass checking by query
            //Succes Login

            User loggedinUser = await _userFacade.GetUserByEmailPasswordAsync(user.Email, user.PasswordHash);


            //if (!ModelState.IsValid)
            //    return View(user);

            // IMPORTANT:
            // First verify user.Email and user.Password
            // against your database using a password hasher.
            //
            // Replace this with your real validation service.
            //bool isValidUser = false;

            //if (!isValidUser)
            //{
            //    ModelState.AddModelError(
            //        "",
            //        "Invalid email or password.");

            //    return View(user);
            //}
            if (loggedinUser == null)
            {
                return RedirectPermanent("/login");
            }


            // Create Claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Email, user.Email)
            };

            // Create Identity
            var claimsIdentity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme
            );

            // Cookie Properties
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = rememberMe,
                ExpiresUtc = DateTimeOffset.UtcNow.AddHours(2)
            };

            // Create Authentication Cookie
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties
            );

            // Redirect after successful login
            return RedirectToAction("Index", "Dashboard");
        }

        [Route(UrlRewrite.Account.Register)]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme
            );

            return RedirectPermanent("/login");
        }
    }
}
