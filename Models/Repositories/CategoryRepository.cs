using Microsoft.EntityFrameworkCore;

namespace BethanysPieShopAdmin.Models.Repositories;

public class CategoryRepository(BethanysPieShopDbContext context) : ICategoryRepository
{
    public async Task<IEnumerable<Category>> GetCategoriesAsync()
    {
        return await context.Categories
            .Include(c => c.Pies)
            .ToListAsync();
    }

    public async Task<Category?> GetCategoryAsync(int? id)
    {
        return await context.Categories
            .Include(c => c.Pies)
            .FirstOrDefaultAsync(c => c.CategoryId == id);
    }

    public async Task<int> AddCategoryAsync(Category category)
    {
        var categoryWithSameNameExist = await context.Categories.AnyAsync(c => c.Name == category.Name);

        if (categoryWithSameNameExist) throw new Exception("A category with the same name already exists");
        context.Categories.Add(category);
        return await context.SaveChangesAsync();
    }
}