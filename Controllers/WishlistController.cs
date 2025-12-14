using Microsoft.AspNetCore.Mvc;

namespace WebApplicationTASK14.Controllers
{
    public class WishlistController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
