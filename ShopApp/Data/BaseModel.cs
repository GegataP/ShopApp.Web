using System.ComponentModel.DataAnnotations;

namespace ShopApp.Data
{
    public abstract class BaseModel
    {
        public BaseModel()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }
    }
}
