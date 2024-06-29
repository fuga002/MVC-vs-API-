using Microsoft.EntityFrameworkCore;
using OnlineShop.Data.Entities;
using DbContext = OnlineShop.Data.Context.DbContext;

namespace OnlineShop.Data.Repositories;

public class ProductRepository:IProductRepository
{
    private readonly DbContext _context;

    public ProductRepository(DbContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetAll()
    {
        var products = await _context.Products.ToListAsync();
        return products;
    }

    public async Task<Product> GetById(int id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

        if (product is null)
            throw new Exception("Not found");
        return product;
    }

    public async Task<Product?> GetByName(string name)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Name == name);
        return product;
    }

    public async Task Add(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Product product)
    {
        
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Product product)
    {
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }
}