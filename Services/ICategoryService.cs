using YourWatch.Admin.Mobile.Models;

namespace YourWatch.Admin.Mobile.Services;

public interface ICategoryService
{
    Task<List<CategoryModel>> GetCategories();
}