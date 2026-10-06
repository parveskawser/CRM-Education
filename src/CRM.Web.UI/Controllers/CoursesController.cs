using Microsoft.AspNetCore.Mvc;

namespace CRM.Web.UI.Controllers
{
    public class CoursesController : Controller
    {
        public IActionResult Index()

        {
            return View();
        }
    }
}
