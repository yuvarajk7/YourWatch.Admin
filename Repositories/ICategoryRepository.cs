using YourWatch.Admin.Mobile.Models;

namespace YourWatch.Admin.Mobile.Repositories;

public interface ICategoryRepository
{
    Task<List<CategoryModel>> GetCategories();
}