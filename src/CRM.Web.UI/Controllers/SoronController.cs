using Microsoft.AspNetCore.Mvc;

namespace CRM.Web.UI.Controllers
{
    public class SoronController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
