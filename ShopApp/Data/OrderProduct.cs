namespace ShopApp.Data
{
    public class OrderProduct : BaseModel
    {
        public Guid ProductId { get; set; }

        public Product Product { get; set; }

        public Guid OrderId { get; set; }

        public Product Order { get; set; }
    }
}
