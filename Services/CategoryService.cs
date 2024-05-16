using YourWatch.Admin.Mobile.Models;
using YourWatch.Admin.Mobile.Repositories;

namespace YourWatch.Admin.Mobile.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public Task<List<CategoryModel>> GetCategories()
        => _categoryRepository.GetCategories();
}