using Microsoft.AspNetCore.Mvc;

namespace CRM.Web.UI.Controllers
{
    public class StudentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
