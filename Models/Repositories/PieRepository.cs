using Microsoft.EntityFrameworkCore;

namespace BethanysPieShopAdmin.Models.Repositories;

public class PieRepository(BethanysPieShopDbContext context) : IPieRepository
{
    public async Task<List<Pie>> GetPiesAsync()
    {
        return await context.Pies.ToListAsync();
    }

    public async Task<Pie?> GetPieAsync(int? id)
    {
        return await context.Pies
            .Include(a => a.Category)
            .Include(v => v.Ingredients)
            .FirstOrDefaultAsync();
    }
}