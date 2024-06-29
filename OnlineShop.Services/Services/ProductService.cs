using OnlineShop.Common.DTOS;
using OnlineShop.Common.Models.ProductModels;
using OnlineShop.Data.Entities;
using OnlineShop.Data.Repositories;
using OnlineShop.Services.Extensions;

namespace OnlineShop.Services.Services;

public class ProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ProductDto>> GetAllProducts()
    {
        var products = await _repository.GetAll();

        return products.ParseToModels();
    }

    public async Task<ProductDto> GetProductById(int productId)
    {
        var product = await _repository.GetById(productId);

        return product.ParseToDto();
    }

    public async Task<ProductDto> AddProduct(CreateProductModel model)
    {
        await CheckExist(model.Name);

        var product = new Product()
        {
            Name = model.Name,
            Description = model.Description,
            Count = model.Count,
            Price = model.Price,
            CategoryId = model.CategoryId
        };

        await _repository.Add(product: product);

        return product.ParseToDto();

    }

    public async Task<ProductDto> UpdateProduct(int productId,UpdateProductModel model)
    {
        var product = await _repository.GetById(productId);

        bool check = false;
        
        if (!string.IsNullOrEmpty(model.Name))
        {
            await CheckExist(model.Name);

            product.Name = model.Name;

            check = true;

        }
        if (!string.IsNullOrEmpty(model.Description))
        {

            product.Description = model.Description;

            check = true;

        }
        if (model.Price > 0)
        {
            product.Price = model.Price;

            check = true;

        }
        if (model.Count > 0)
        {
            product.Count = model.Count;

            check = true;

        }

        if (check)
            await _repository.Update(product);

        return product.ParseToDto();
    }

    public async Task<string> DeleteProduct(int productId)
    {
        var product = await _repository.GetById(productId);

        await _repository.Delete(product: product);

        return "Deleted successfully";
    }
    

    private async Task CheckExist(string name)
    {
        var product = await _repository.GetByName(name);

        if (product is not null)
            throw new Exception("It is already exist");
    }
}