namespace BethanysPieShopAdmin.Models.Repositories;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetCategoriesAsync();
    Task<Category?> GetCategoryAsync(int? id);
    Task<int> AddCategoryAsync(Category category);
}