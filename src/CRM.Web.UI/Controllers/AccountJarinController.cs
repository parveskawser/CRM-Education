using Microsoft.AspNetCore.Mvc;

namespace CRM.Web.UI.Controllers
{
    public class AccountJarinController : Controller
    {
 
        public IActionResult Login()
        {
            return View();
        }

        
        public IActionResult Register()
        {
            return View();
        }
    }
}
