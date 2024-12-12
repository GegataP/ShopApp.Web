﻿using Microsoft.AspNetCore.Identity;
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
            return View();
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
