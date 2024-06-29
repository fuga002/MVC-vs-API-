using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Common.Models.ProductModels;

public class CreateProductModel
{
    [Required] public string Name { get; set; }
    [Required] public string Description { get; set; }
    public decimal Price { get; set; }
    public int Count { get; set; }
    public int CategoryId { get; set; }
}
