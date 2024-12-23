using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static ShopApp.Common.EnityValidationConstants.SliderImg;

namespace ShopApp.Data
{
    public class SliderImage : BaseModel
    {
        
        public string Name { get; set; } = null!;

        [MaxLength( SliderImgUrlMaxLength)]
        public string Image { get; set; } = null!;

        [Required]
        [DisplayName("Sort Order")]
        public int SortedOrder { get; set; }
    }
}
