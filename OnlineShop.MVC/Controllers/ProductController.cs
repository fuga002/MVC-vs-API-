using Microsoft.AspNetCore.Mvc;
using OnlineShop.Common.Models.ProductModels;
using OnlineShop.Services.Services;

namespace OnlineShop.MVC.Controllers;

public class ProductController : Controller
{
    private readonly ProductService _service;

    public ProductController(ProductService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _service.GetAllProducts();
        
        return View(products);
    }

    public async Task<IActionResult> AddProduct()
    {
        var model = new CreateProductModel();

        return View(model: model);
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct(CreateProductModel model)
    {
        await _service.AddProduct(model);

        return RedirectToAction("Index");
    }
}