using ShopApp.Data;

namespace ShopApp.Services.ProductService
{
    public interface IProductService
    {
        void Create(Product product);

        void Edit(Product product);

        void Delete(Product product);
    }
}
