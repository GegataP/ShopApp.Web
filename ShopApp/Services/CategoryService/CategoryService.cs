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

        // create category
        public void Create(Category category)
        {
            applicationDbContext.Add(category);
            applicationDbContext.SaveChanges();
        }

        //edit category 
        public void Edit(Category category) 
        {
           
            applicationDbContext.Update(category);
            applicationDbContext.SaveChanges();
            
        }

        //delete category
        public void Delete(Category category)
        {
            applicationDbContext.Remove(category);

        }

    }
}
