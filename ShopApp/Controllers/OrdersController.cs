using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopApp.Data;

namespace ShopApp.Controllers
{
    public class OrdersController : Controller
    {
        public readonly ApplicationDbContext _context;
        public readonly UserManager<User> _userManager;

        public OrdersController(UserManager<User> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            var orders = await _context.Orders
                .Where(x => x.UserId == Guid.Parse(currentUser.Id))
                .ToListAsync();

            return View(orders);
        }
        public async Task<IActionResult> Details(Guid id)
        {
            
            var order = await _context.Orders
                .Include(x => x.OrderProducts)
                .ThenInclude(p=> p.Product)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (order != null)
            {
                foreach (var orderProduct in order.OrderProducts)
                {
                    Console.WriteLine($"Product Name: {orderProduct.Product?.Name}");
                }
            }

            return View(order);
        }

    }
}
