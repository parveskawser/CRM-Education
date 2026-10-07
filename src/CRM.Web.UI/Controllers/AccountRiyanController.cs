using CRM.Framework;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Web.UI.Controllers
{
    public class AccountRiyanController : Controller
    {
        [Route(UrlRewrite.AccountRiyan.Login)]
        public IActionResult Login()
        {
            return View();
        }

        [Route(UrlRewrite.AccountRiyan.Register)]
        public IActionResult Register()
        {
            return View();
        }
    }
}