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
}

public interface ICategoryRepository
{
     Task<IEnumerable<Category>> GetCategoriesAsync();
     Task<Category?> GetCategoryAsync(int? id);
}