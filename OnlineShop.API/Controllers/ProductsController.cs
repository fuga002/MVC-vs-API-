using Microsoft.AspNetCore.Mvc;
using OnlineShop.Common.DTOS;
using OnlineShop.Common.Models.ProductModels;
using OnlineShop.Services.Services;

namespace OnlineShop.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{

    private readonly ProductService _productService;

    public ProductsController(ProductService productService)
    {
        _productService = productService;
    }


    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        try
        {
            var products = await _productService.GetAllProducts();
            return Ok(products);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        try
        {
            var product = await _productService.GetProductById(id);
            return Ok(product);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    [HttpPost]
    public async Task<IActionResult> AddProduct([FromBody]CreateProductModel model)
    {
        try
        {
            var product = await _productService.AddProduct(model);
            return Ok(product);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateProduct(int id,[FromBody]UpdateProductModel model)
    {
        try
        {
            var product = await _productService.UpdateProduct(id, model);
            return Ok(product);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        try
        {
            var result = await _productService.DeleteProduct(id);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}