using Microsoft.AspNetCore.Mvc;

namespace CRM.Web.UI.Controllers
{
    public class BatchesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
