using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ShopApp.Data
{
    public class User : IdentityUser
    {
        public ICollection<Order> Orders { get; set; }

    }
}
