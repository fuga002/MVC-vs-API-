using OnlineShop.Data.Entities;

namespace OnlineShop.Data.Repositories;

public interface IProductRepository
{
    Task<List<Product>> GetAll();
    Task<Product> GetById(int id);
    Task<Product?> GetByName(string name);
    Task Add(Product product);
    Task Update(Product product);
    Task Delete(Product product);
}