using Microsoft.AspNetCore.Mvc;
using WebApplicationTASK14.DAL;
using WebApplicationTASK14.Models;
namespace WebApplicationTASK14.Controllers
{
    public class HomeController : Controller
    {
        public readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            //_context.Slides.AddRange(slides);
            //_context.SaveChanges();

            

            return View();
        }
    }
}
