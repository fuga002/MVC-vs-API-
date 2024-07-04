using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Data.Repositories;
using OnlineShop.Services.Services;

namespace OnlineShop.Services.Extensions;

public static  class ServiceExtension
{
    public static void AddServices(this IServiceCollection collection)
    {
        collection.AddScoped<ICategoryRepository, CategoryRepository>();
        collection.AddScoped<IProductRepository, ProductRepository>();
        collection.AddScoped<CategoryService>();
        collection.AddScoped<ProductService>();
    }
    
}