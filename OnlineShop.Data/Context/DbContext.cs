using Microsoft.EntityFrameworkCore;
using OnlineShop.Data.Entities;

namespace OnlineShop.Data.Context;

public class DbContext:Microsoft.EntityFrameworkCore.DbContext
{
    public DbContext(DbContextOptions<DbContext> options) : base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
}