using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ShopApp.Data;

namespace ShopApp.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext applicationDbContext;
        public CategoryService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public void Create(Category category)
        {
            applicationDbContext.Add(category);
            applicationDbContext.SaveChangesAsync();
        }

    }
}
