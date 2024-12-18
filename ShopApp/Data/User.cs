using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static ShopApp.Common.EnityValidationConstants.User;

namespace ShopApp.Data
{
    public class User : IdentityUser
    {
        [Required]
        [MaxLength(UserFirstNameMaxLength)]
        public string FirstName { get; set; }

        [MaxLength(UserLastNameMaxLength)]
        [Required]
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        //public ICollection<Order> Orders { get; set; }

    }
}
