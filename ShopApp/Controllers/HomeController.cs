using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopApp.Data;
using ShopApp.Models;
using ShopApp.ViewModels;
using System.Diagnostics;

namespace ShopApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            //var products = await _context.Products.ToListAsync();

            var sliderImages = await _context.SliderImages
                .OrderBy(x=>x.SortedOrder)
                .ToListAsync();

            var categories = await _context.Categories.ToListAsync();

            var model = new HomeViewModel { 
                //Products = products,
                SliderImages = sliderImages,
                Categories = categories
            };

            return View("~/Views/Home/Index.cshtml", model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
