using Microsoft.AspNetCore.Mvc;

namespace CRM.Web.UI.Controllers
{
    public class AccountSrabonController : Controller
    {
        public IActionResult Registration()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
