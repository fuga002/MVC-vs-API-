using Mapster;
using OnlineShop.Common.DTOS;
using OnlineShop.Data.Entities;

namespace OnlineShop.Services.Extensions;

public static  class ParseExtension
{
    public static CategoryDto  ParseToDto(this Category model)
    {
        return new CategoryDto()
        {
            Id = model.Id,
            Name = model.Name,
            Description = model.Description,
            CreatedAt = model.CreatedAt,
            Products = model.Products.ParseToModels()
        };
    }

    public static List<CategoryDto> ParseToDtoS(this List<Category>? models)
    {
        var dtos = new List<CategoryDto>();
        if (models == null || models.Count == 0)
            return dtos;
        foreach (var category in models)
        {
            
            dtos.Add(category.ParseToDto());
        }
        
        return dtos;
    }

    public static ProductDto ParseToDto(this Product model)
    {
        var dto = model.Adapt<ProductDto>();
        
        return dto;
    }

    public static List<ProductDto> ParseToModels(this List<Product>? models)
    {
        var dtos = new List<ProductDto>();

        if (models == null || models.Count == 0)
            return dtos;
        
        foreach (var model in models)
        {
            dtos.Add(model.ParseToDto());
        }

        return dtos;
    }
}