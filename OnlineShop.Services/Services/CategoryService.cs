using OnlineShop.Common.DTOS;
using OnlineShop.Common.Models.CategoryModels;
using OnlineShop.Data.Entities;
using OnlineShop.Data.Repositories;
using OnlineShop.Services.Extensions;

namespace OnlineShop.Services.Services;

public class CategoryService
{
    private readonly ICategoryRepository _repository;

    public CategoryService(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<CategoryDto>> GetAllCategory()
    {
        var categories = await _repository.GetAll();
        return categories.ParseToDtoS();
    }

    public async Task<CategoryDto> GetCategoryById(int categoryId)
    {
        var category = await _repository.GetById(categoryId);

        return category.ParseToDto();
    }


    public async Task<CategoryDto> AddCategory(CreateCategoryModel model)
    {
        await IsExist(model.Name);
        
        var categoryModel = new Category()
        {
            Name = model.Name,
            Description = model.Description
        };

        await _repository.Add(categoryModel);
        return categoryModel.ParseToDto();
    }

    public async Task<CategoryDto> UpdateCategory(int categoryId,UpdateCategoryModel model)
    {

        bool check = false;
        
        var category = await _repository.GetById(categoryId);
        
        if (!string.IsNullOrEmpty(model.Name))
        {
            await IsExist(model.Name);
            
            category.Name = model.Name;

            check = true;
        }

        if (!string.IsNullOrEmpty(model.Description))
        {
            category.Description = model.Description;

            check = true;
        }

        if(check)
            await _repository.Update(category);
        
        return category.ParseToDto();
    }

    public async Task<string> DeleteCategory(int categoryId)
    {
        var category = await _repository.GetById(categoryId);

        await _repository.Delete(category);

        return "Deleted successfully";
    }


    private async Task IsExist(string name)
    {
        var category = await _repository.GetByName(name);

        if (category is not null)
            throw new Exception("It is already exist");
    }
}