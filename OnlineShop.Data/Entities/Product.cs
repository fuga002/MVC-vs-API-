using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Data.Entities;

public class Product
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Count { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public string? PhotoUrl { get; set; }
    
    public int CategoryId { get; set; }
    public virtual Category? Category { get; set; }
}