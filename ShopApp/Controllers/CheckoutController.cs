
using Humanizer.Localisation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopApp.Data;

namespace ShopApp.Controllers
{
    public class CheckoutController : Controller
    {
        public readonly ApplicationDbContext _context;
        public readonly UserManager<User> _userManager;
        
        public CheckoutController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            var addresses = await _context.Addresses
                .Include(x => x.User)
                .Where(x => x.UserId == Guid.Parse(currentUser.Id))
            .ToListAsync();

            

            ViewBag.Addresses = addresses;

            return View();
        }



        public async Task<IActionResult> Confirm(Guid addressId)
        {
            

            var address = await _context.Addresses.Where(x=> x.Id== addressId).FirstOrDefaultAsync();

            if (address == null) 
            {
                return BadRequest();
            }

            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            decimal orderCost = 0;

            var carts = await _context.Carts
                .Include(x => x.Product)
                .Where(x=>x.UserId == Guid.Parse(currentUser.Id))
                .ToListAsync();

            foreach (var cart in carts) 
            {
                orderCost += (cart.Product.Price * cart.Quantity);
            }

            var order = new Order
            {
                AddressId = addressId,
                CreatedAt = DateTime.Now,
                Status = "Order Placed",
                UserId = Guid.Parse(currentUser.Id),
                Amount = orderCost,
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            foreach (var cart in carts)
            {
                var orderProduct = new OrderProduct
                {
                    ProductId = cart.ProductId,
                    OrderId = order.Id,
                    Price=cart.Product.Price,
                    Quantity=cart.Quantity,
                };

                _context.Add(orderProduct);
                
            }
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Orders");
        }

        

        

        [HttpPost]
        public async Task<IActionResult> Index(Address address)
        {
           if (ModelState.IsValid)
           {
               var currentUser = await _userManager.GetUserAsync(HttpContext.User);
        
               address.UserId = Guid.Parse(currentUser.Id);
        
               _context.Addresses.Add(address);
               await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    return View(address);
}
}
}
