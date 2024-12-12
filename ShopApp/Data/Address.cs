using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace ShopApp.Data
{
    public class Address : BaseModel
    {
        public Guid UserId { get; set; }

       
        public User User { get; set; }

        [Required]
        public string AddressLine { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string PinCode { get; set; }
    }
}
