using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ShopApp.Data;

namespace ShopApp.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        public readonly ApplicationDbContext _context;
        public readonly UserManager<IdentityUser> _userManager;

        public CartController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task <IActionResult> AddToCart(Guid productId, int quantity = 1)
        {

            var currentUser=await _userManager.GetUserAsync(HttpContext.User);

            var product = await _context.Products.Where(x => x.Id == productId).FirstOrDefaultAsync();

            if (product == null)
            {
                return BadRequest();
            }

            

            var cart = new Cart {
                ProductId = productId, 
                Quantity = quantity, 
                UserId = Guid.Parse(currentUser.Id)
            };

            // for service
            _context.Add(cart);
             await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        
    }
}
