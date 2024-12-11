using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopApp.Data
{
    public class Cart : BaseModel
    {
        [Required]
        public Guid ProductId { get; set; }

        
        [ForeignKey("OrderProductId")]
        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
