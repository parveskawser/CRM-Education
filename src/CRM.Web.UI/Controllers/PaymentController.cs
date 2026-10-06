using Microsoft.AspNetCore.Mvc;

namespace CRM.Web.UI.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
