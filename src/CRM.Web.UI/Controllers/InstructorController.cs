using Microsoft.AspNetCore.Mvc;

namespace CRM.Web.UI.Controllers
{
    public class InstructorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
