namespace OnlineShop.Common.Models.ProductModels;

public class UpdateProductModel
{
    
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int Count { get; set; }
}