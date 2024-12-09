using Microsoft.Extensions.Hosting;
using ShopApp.Data;
using System;

namespace ShopApp.Services.CategoryService
{
    public interface ICategoryService
    {
        void Create(Category category);
    }
}
