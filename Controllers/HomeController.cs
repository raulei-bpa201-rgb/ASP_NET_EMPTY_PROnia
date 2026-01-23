using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApplicationTASK14.DAL;
using WebApplicationTASK14.Models;
using WebApplicationTASK14.ViewModels;
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
            

            List<Slide> slides = _context.Slides.ToList();
            HomeVM homeVM = new HomeVM()
            {
                Slides = slides,
                Products = _context.Products.Include(p=>p.Images).Include(p => p.Category).ToList()
            };



            return View(homeVM);
        }
    }
}
