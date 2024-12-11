using System.ComponentModel.DataAnnotations;
using static ShopApp.Common.EnityValidationConstants.Product;

namespace ShopApp.Data
{
    public class Product : BaseModel
    {
        [Required]
        [MaxLength(ProductNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [MaxLength(ProductDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [MaxLength(ProductImgUrlMaxLength)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public Guid CategoryId { get; set; }

        public Category Category { get; set; }

    }
}
