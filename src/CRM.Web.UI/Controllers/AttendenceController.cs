using Microsoft.AspNetCore.Mvc;

namespace CRM.Web.UI.Controllers
{
    public class AttendenceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
