using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopApp.Data
{
    public class Cart : BaseModel
    {
        
        public Guid ProductId { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }
    }
}
