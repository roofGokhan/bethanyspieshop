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
}

public interface ICategoryRepository
{
     Task<IEnumerable<Category>> GetCategoriesAsync();
}