using Microsoft.AspNetCore.Mvc;
using OnlineShop.Common.Models.CategoryModels;
using OnlineShop.Services.Services;

namespace OnlineShop.MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllCategory();
            return View(categories);
        }

        public async Task<IActionResult> AddCategory()
        {
            var createCategoryModel = new CreateCategoryModel();
            return View(createCategoryModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CreateCategoryModel model)
        {
            await _categoryService.AddCategory(model: model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            return View(category);
        }
        
        
    }
}
