using Microsoft.EntityFrameworkCore;
using OnlineShop.Data.Entities;
using DbContext = OnlineShop.Data.Context.DbContext;

namespace OnlineShop.Data.Repositories;

public class CategoryRepository:ICategoryRepository
{
    private readonly DbContext _context;

    public CategoryRepository(DbContext context)
    {
        _context = context;
    }

    public async Task<List<Category>> GetAll()
    {
        var categories = await _context.Categories.ToListAsync();
        return categories;
    }

    public async Task<Category> GetById(int id)
    {
        var category = await _context.Categories.
            FirstOrDefaultAsync(c => c.Id == id);

        if (category is null)
            throw new Exception("Not found");

        return category;

    }

    public async Task<Category?> GetByName(string name)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(c => c.Name == name);
        return category;
    }

    public async Task Add(Category category)
    {
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Category category)
    {
        _context.Categories.Update(category);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Category category)
    {
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
    }
}