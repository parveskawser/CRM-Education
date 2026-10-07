using Microsoft.AspNetCore.Mvc;

namespace CRM.Web.UI.Controllers
{
    public class AccountApelController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Registration()
        {
            return View();
        }
    }
}
