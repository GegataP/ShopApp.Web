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
        public readonly UserManager<User> _userManager;

        public CartController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            var cart = await _context.Carts
                .Include(x=>x.Product)
                .Where(x => x.UserId == Guid.Parse(currentUser.Id))
                .ToListAsync();

            decimal totalCost = 0;

            foreach (var cartItem in cart)
            {
                totalCost += cartItem.Product.Price * cartItem.Quantity;
            }

            ViewBag.TotalCost = totalCost;

            return View(cart);
        }

        public async Task<IActionResult> UpdateQty(Guid productId, int qty)
        {
            var product = await _context.Products.Where(x => x.Id == productId).FirstOrDefaultAsync();

            if (product == null)
            {
                return BadRequest();
            }

            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            var cartItem = await _context.Carts
                .Where(x=>x.UserId == Guid.Parse(currentUser.Id))
                .Where(x => x.ProductId == productId)
                .FirstOrDefaultAsync();

            if (cartItem == null) 
            {
                return BadRequest();
            }

            cartItem.Quantity = qty;
            _context.Carts.Update(cartItem);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> AddToCart(Guid productId, int quantity = 1)
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

        public async Task<IActionResult> Remove(Guid id)
        {
            var cartItem = await _context.Carts.FindAsync(id);

            if (cartItem == null)
            { 
                return BadRequest();
            }

            _context.Carts.Remove(cartItem);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        
    }
}
