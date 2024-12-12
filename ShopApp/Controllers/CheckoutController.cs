using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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



        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index(Address address)
        {


            return View();
        }
    }
}
