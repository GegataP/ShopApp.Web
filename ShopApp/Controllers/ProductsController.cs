using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopApp.Data;
using ShopApp.ViewModels;

namespace ShopApp.Controllers
{
    public class ProductsController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Products/Index")]
        public async Task<IActionResult> Index(Guid? categoryId)
        {


            var productsQuery = _context.Products.AsQueryable();

            if (categoryId != null)
            {
                 productsQuery = productsQuery
                    .Where(x => x.CategoryId == categoryId);
                    
            }

            var products = await productsQuery
        .Select(x => new ProductViewModel
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            Price = x.Price,
            ImageUrl = x.ImageUrl
        })
        .ToListAsync();

            return View(products);
        }

        //[HttpGet]
        //[Route("Products/Index")]
        //public async Task<IActionResult> Index()
        //{
        //    var products = await _context.Products.ToListAsync();
        //
        //    return View(products);
        //}

        public async Task<IActionResult> Details(Guid? id) 
        {

            var product = await _context.Products
                .Select(x => new ProductViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Price = x.Price,
                    ImageUrl = x.ImageUrl
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);

            //var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            //if (product == null) 
            //{ 
            //    return NotFound();
            //}
            //return View(product);
        }
    }
}
