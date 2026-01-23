using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationTASK14.DAL;
using WebApplicationTASK14.Models;
using WebApplicationTASK14.ViewModels;

namespace WebApplicationTASK14.Controllers
{
    public class ShopController : Controller
    {
        public readonly AppDbContext _context;

        public ShopController(AppDbContext context) 
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail(int id)
        {
            if (id == null || id < 0)
            {
                return BadRequest();
            }

            Product product = _context.Products.Include(p => p.Category).Include(p => p.Images).FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound(product);
            }

            List<Product> products = _context.Products.Include(p=>p.Category).Include(p => p.Images).Where(p => p.CategoryId == product.CategoryId&& p.Id != id).ToList();

            DetailVM detailVM = new DetailVM
            { 
                Product = product,
                RelatedProducts = products
            };

            return View(detailVM);
        }
    }
}
