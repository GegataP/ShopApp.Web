using System.ComponentModel.DataAnnotations;

namespace ShopApp.Data
{
    public class Category : BaseModel
    {
        public Category() {
            this.Products = new HashSet<Product>();
        }
        [Required]
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
