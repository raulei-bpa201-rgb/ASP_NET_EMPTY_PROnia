using Microsoft.AspNetCore.Mvc;

namespace WebApplicationTASK14.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
