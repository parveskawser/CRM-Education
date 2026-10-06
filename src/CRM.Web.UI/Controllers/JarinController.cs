using Microsoft.AspNetCore.Mvc;

namespace CRM.Web.UI.Controllers
{
    public class JarinController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
