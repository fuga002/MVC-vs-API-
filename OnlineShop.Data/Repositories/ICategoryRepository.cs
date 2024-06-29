using OnlineShop.Data.Entities;

namespace OnlineShop.Data.Repositories;

public interface ICategoryRepository
{
    Task<List<Category>> GetAll();
    Task<Category> GetById(int id);
    Task<Category?> GetByName(string name);
    Task Add(Category category);
    Task Update(Category category);
    Task Delete(Category category);
}