using CRM.Framework;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Web.UI.Controllers
{
    public class AccountController : Controller
    {
        [Route(UrlRewrite.Account.Login)]
        public IActionResult Login()
        {
            return View();
        }

        [Route(UrlRewrite.Account.Register)]
        public IActionResult Register()
        {
            return View();
        }

    }
}
