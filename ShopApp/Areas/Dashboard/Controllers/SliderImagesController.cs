using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopApp.Data;
using static ShopApp.Common.EnityValidationConstants;

namespace ShopApp.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class SliderImagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SliderImagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Dashboard/SliderImages
        public async Task<IActionResult> Index()
        {
            return View(await _context.SliderImages.ToListAsync());
        }

        // GET: Dashboard/SliderImages/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sliderImage = await _context.SliderImages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sliderImage == null)
            {
                return NotFound();
            }

            return View(sliderImage);
        }

        // GET: Dashboard/SliderImages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dashboard/SliderImages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(SliderImage sliderImage, IFormFile Image)
        {
            
                if (Image == null)
                {
                    ModelState.AddModelError(nameof(SliderImage.Image), "Image is required.");
                    return View(sliderImage);
                }

                var imageName = Guid.NewGuid() + Path.GetExtension(Image.FileName);

                if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/SliderImages")))
                {
                    Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/SliderImages"));
                }

                var savePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/SliderImages", imageName);

                await using (var stream = new FileStream(savePath, FileMode.Create))
                {
                    await Image.CopyToAsync(stream);
                }

                sliderImage.Image = $"/img/SliderImages/{imageName}";

            if (ModelState.IsValid)
            {

                sliderImage.Id = Guid.NewGuid();
                    _context.Add(sliderImage);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
            }
            
            return View(sliderImage);
        }


        //public async Task<IActionResult> Create(SliderImage sliderImage, IFormFile Image)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (Image == null)
        //        {
        //            ModelState.AddModelError(nameof(SliderImage.Iamge), "Image is required.");
        //            return View(sliderImage);
        //        }
        //
        //        var imageName = Guid.NewGuid() + Path.GetExtension(Image.FileName);
        //
        //        if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/SliderImages")))
        //        {
        //            Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/SliderImages"));
        //        }
        //
        //        var savePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/SliderImages", imageName);
        //
        //        await using (var stream = new FileStream(savePath, FileMode.Create))
        //        {
        //            await Image.CopyToAsync(stream);
        //        }
        //
        //        sliderImage.Iamge = $"/img/SliderImages/{imageName}";
        //
        //        _context.Add(sliderImage);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(sliderImage);
        //}

        // GET: Dashboard/SliderImages/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sliderImage = await _context.SliderImages.FindAsync(id);
            if (sliderImage == null)
            {
                return NotFound();
            }
            return View(sliderImage);
        }

        // POST: Dashboard/SliderImages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Iamge,SortedOrder,Id")] SliderImage sliderImage)
        {
            if (id != sliderImage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sliderImage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SliderImageExists(sliderImage.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(sliderImage);
        }

        // GET: Dashboard/SliderImages/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sliderImage = await _context.SliderImages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sliderImage == null)
            {
                return NotFound();
            }

            return View(sliderImage);
        }

        // POST: Dashboard/SliderImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var sliderImage = await _context.SliderImages.FindAsync(id);
            if (sliderImage != null)
            {
                _context.SliderImages.Remove(sliderImage);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SliderImageExists(Guid id)
        {
            return _context.SliderImages.Any(e => e.Id == id);
        }
    }
}
