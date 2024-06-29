namespace OnlineShop.Common.DTOS;

public class ProductDto
{
    
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Count { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public string? PhotoUrl { get; set; }
    
    public int CategoryId { get; set; }
}