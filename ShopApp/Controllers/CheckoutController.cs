using Microsoft.AspNetCore.Mvc;
using ShopApp.Data;

namespace ShopApp.Controllers
{
    public class CheckoutController : Controller
    {
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
