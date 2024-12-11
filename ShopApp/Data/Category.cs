using System.ComponentModel.DataAnnotations;
using static ShopApp.Common.EnityValidationConstants.Category;

namespace ShopApp.Data
{
    public class Category : BaseModel
    {
        public Category() {
            this.Products = new HashSet<Product>();
        }
        [Required]
        [MaxLength(CategoryNameMaxLength)]
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
