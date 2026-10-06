using Microsoft.AspNetCore.Mvc;

namespace CRM.Web.UI.Controllers
{
    public class ApelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
