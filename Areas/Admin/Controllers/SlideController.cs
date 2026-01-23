using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.ComponentModel.DataAnnotations;
using WebApplicationTASK14.Areas.Admin.ViewModels;
using WebApplicationTASK14.DAL;
using WebApplicationTASK14.Models;
using WebApplicationTASK14.Utilites.Enums;
using WebApplicationTASK14.Utilites.Extensions;
using static System.Net.Mime.MediaTypeNames;

namespace WebApplicationTASK14.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SlideController : Controller
    {
        readonly AppDbContext _context;

        readonly IWebHostEnvironment _env;
        public SlideController(AppDbContext context , IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<Slide> slides = await _context.Slides.ToListAsync();

            return View(slides);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(Slide slide)
        {

            if (slide.Photo.ValidationType("image/"))
            {
                ModelState.AddModelError("Photo", "Duzgun format deyil");
                return View();
            }

            if (slide.Photo.ValidationSize(FileSize.MB,4))
            {
                ModelState.AddModelError("Photo", "Too YOUNG");
                return View();
            }


            slide.Image = await slide.Photo.CreateFile(_env.WebRootPath, "assets", "images", "website-images");
             
            await _context.Slides.AddAsync(slide);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id < 0)
            {
                return BadRequest();
            }

            Slide slide = await _context.Slides.FirstOrDefaultAsync(p=>p.Id == id);

            if (slide == null)
            {
                return NotFound();
            }

            slide.Image.DeleteFile(_env.WebRootPath, "assets", "images", "website-images");

            _context.Slides.Remove(slide);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id < 0)
            {
                return BadRequest();
            }

            Slide slide = await _context.Slides.FirstOrDefaultAsync(s=>s.Id == id);

            UpdateSlideVM createSlide = new UpdateSlideVM()
            {
                Title = slide.Title,
                Discount = slide.Discount,
                Order = slide.Order,
                Description = slide.Description,
                Image = slide.Image
            };


            if (slide == null)
            {
                return BadRequest();
            }

            return View(createSlide);
        }

        [HttpPost]

        public async Task<IActionResult> Update(int? id,UpdateSlideVM createSlide)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Title", "Ad daxil olunmuyub");
                return View();
            }

            Slide slide = await _context.Slides.FirstOrDefaultAsync(p=>p.Id == id);

            if (createSlide.Photo is not null)
            {
                if (createSlide.Photo.ValidationType("image/"))
                {
                    ModelState.AddModelError("Photo", "Type is wrong");
                    return View();
                }

                if (createSlide.Photo.ValidationSize(FileSize.MB,4))
                {
                    ModelState.AddModelError("Photo", "Size is too small");
                    return View();
                }

                createSlide.Image = await createSlide.Photo.CreateFile(_env.WebRootPath,"assets","images","website-images");
                slide.Image.DeleteFile(_env.WebRootPath, "assets", "images", "website-images");
            }
            slide.Title = createSlide.Title;
            slide.Description = createSlide.Description;
            slide.Discount = createSlide.Discount;
            slide.Order = createSlide.Order;
            slide.Image = createSlide.Image;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
