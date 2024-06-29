﻿namespace OnlineShop.Common.DTOS;

public class CategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; } 
        
    public List<ProductDto>? Products { get; set; }
}