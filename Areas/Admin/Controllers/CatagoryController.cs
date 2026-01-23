using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplicationTASK14.DAL;
using WebApplicationTASK14.Models;

namespace WebApplicationTASK14.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CatagoryController : Controller
    {
        public readonly AppDbContext _context;

        public CatagoryController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Category> categories = await _context.Categories.ToListAsync();

            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            bool IsRepeated = await _context.Categories.AnyAsync(p=>p.Name == category.Name);

            if (IsRepeated)
            {
                ModelState.AddModelError("Name", "This already in data base");
                return View();
            }

            await _context.AddAsync(category);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id < 1)
            {
                BadRequest();
            }

            Category category = await _context.Categories.FirstOrDefaultAsync(p => p.Id == id);

            if (category is null)
            {
                NotFound();
            }



            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id,Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Category exists = await _context.Categories.FirstOrDefaultAsync(p => p.Name == category.Name);

            if (exists is not null)
            {
                ModelState.AddModelError("Name","Already yest");
                return View();
            }

            Category category1 = await _context.Categories.FirstOrDefaultAsync(p => p.Id == id);

            category1.Name = category.Name;
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null || id < 1)
            {
                BadRequest();
            }

            Category category = await _context.Categories.FirstOrDefaultAsync(p => p.Id == id);

            if (category is null)
            {
                NotFound();
            }
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null || id < 1)
            {
                BadRequest();
            }

            Category category = await _context.Categories.FirstOrDefaultAsync(p => p.Id == id);

            if (category is null)
            {
                NotFound();
            }

            return View(category);
        }
    }
}
