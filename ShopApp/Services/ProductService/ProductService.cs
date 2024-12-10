using ShopApp.Data;

namespace ShopApp.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext applicationDbContext;
        public ProductService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public void Create(Product product)
        {
            applicationDbContext.Add(product);
            applicationDbContext.SaveChanges();
        }

        public void Edit(Product product)
        {
            applicationDbContext.Update(product);
            applicationDbContext.SaveChanges();
        }

        public void Delete(Product product) 
        {
            applicationDbContext.Remove(product);
        }

    }
}
