using Microsoft.AspNetCore.Mvc;

namespace CRM.Web.UI.Controllers
{
    public class RapidController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
