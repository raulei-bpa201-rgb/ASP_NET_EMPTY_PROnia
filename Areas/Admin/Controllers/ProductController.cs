using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationTASK14.Areas.Admin.ViewModels.Product;
using WebApplicationTASK14.DAL;
using WebApplicationTASK14.Models;

namespace WebApplicationTASK14.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        readonly AppDbContext _context;

        readonly IWebHostEnvironment _env;

        public ProductController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<ActionResult> Index()
        {
            List<GetProductVM> productVMs = await _context.Products.Include(p => p.Category).Include(p => p.Images.Where(p => p.IsPrimary == true)).Select(p => new GetProductVM 
            {
                Id = p.Id,
                Name = p.Name,
                SKU = p.SKU,
                CategoryName = p.Category.Name,
                Image = p.Images[0].Image
            }).ToListAsync();


            return View(productVMs);
        }

        public async Task<ActionResult> Create()
        {
            CreateProductVM productVM = new CreateProductVM() 
            {
                Categorys = await _context.Categories.ToListAsync()
            };


            return View(productVM);
        }

        [HttpPost]

        public async Task<ActionResult> Create(CreateProductVM createProductVM)
        {
            createProductVM.Categorys = await _context.Categories.ToListAsync();

            if (!ModelState.IsValid)
            {
                return View(createProductVM);
            }

            bool result = await _context.Categories.AnyAsync(p=>p.Id == createProductVM.CategoryId);

            if (!result)
            {
                ModelState.AddModelError("CatagoryName", "no this");
                return View(createProductVM);
            }

            Product product = new Product()
            {
                Name = createProductVM.Name,
                SKU = createProductVM.SKU,
                Price = createProductVM.Price,
                Description = createProductVM.Description,
                CategoryId = createProductVM.CategoryId
            };

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
