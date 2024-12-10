using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopApp.Data
{
    public class Cart : BaseModel
    {
        [Required]
        public Guid OrderProductId { get; set; }

        
        [ForeignKey("OrderProductId")]
        public OrderProduct OrderProduct { get; set; }

        [Required]
        public Guid UserID { get; set; }

        [ForeignKey("UserID")]
        public User User { get; set; }
    }
}
