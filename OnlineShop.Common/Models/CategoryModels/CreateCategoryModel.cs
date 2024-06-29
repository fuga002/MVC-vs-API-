using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Common.Models.CategoryModels;

public class CreateCategoryModel
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
        
}