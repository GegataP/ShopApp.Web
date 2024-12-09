using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopApp.Data
{
    public class Order : BaseModel
    {
        public DateTime OrderDate { get; set; }

        [Required]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
