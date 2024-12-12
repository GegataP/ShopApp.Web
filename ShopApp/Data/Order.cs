namespace ShopApp.Data
{
    public class Order : BaseModel
    {
        public Guid UserId { get; set; }

        public User User { get; set; }

        public Guid AddressId { get; set; }

        public Address Address { get; set; }

        public decimal Amount { get; set; }

        public string Status { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
