using CRM.Framework;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Web.UI.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
         

        [Route(UrlRewrite.Admin.CourseList)]
        public IActionResult Course()
        {
            
            return View();
        }
    }
}
