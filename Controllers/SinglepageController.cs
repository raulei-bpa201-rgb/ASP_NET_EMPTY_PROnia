using Microsoft.AspNetCore.Mvc;

namespace WebApplicationTASK14.Controllers
{
    public class SinglepageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
