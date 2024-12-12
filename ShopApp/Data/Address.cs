using System.Reflection.Metadata.Ecma335;

namespace ShopApp.Data
{
    public class Address : BaseModel
    {
        public Guid UserId { get; set; }

        public User User { get; set; }

        public string AddressLine { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string PinCode { get; set; }
    }
}
