using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopApp.Data;

namespace ShopApp.Controllers
{
    public class OrdersController : Controller
    {
        public readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _context.Orders.ToListAsync();

            return View(orders);
        }
        public async Task<IActionResult> Details(Guid id)
        {
            var order = await _context.Orders
                .Include(x => x.OrderProducts)
                .ThenInclude(p=> p.Product)
                .FirstOrDefaultAsync(x => x.Id == id);

            return View(order);
        }

    }
}
