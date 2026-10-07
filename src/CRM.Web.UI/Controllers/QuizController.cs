using CRM.Framework;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Web.UI.Controllers
{
    public class QuizController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
       
        public IActionResult Login()
        {
            return View();
        }
       
        public IActionResult Registration()
        {
            return View();
        }
    }
}
