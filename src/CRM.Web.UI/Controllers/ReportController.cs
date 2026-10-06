using Microsoft.AspNetCore.Mvc;

namespace CRM.Web.UI.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
