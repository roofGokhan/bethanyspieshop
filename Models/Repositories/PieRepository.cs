using Microsoft.EntityFrameworkCore;

namespace BethanysPieShopAdmin.Models.Repositories;

public class PieRepository(BethanysPieShopDbContext context) : IPieRepository
{
    public async Task<List<Pie>> GetPiesAsync()
    {
        return await context.Pies.OrderBy(a => a.PieId).ToListAsync();
    }

    public async Task<Pie?> GetPieAsync(int? id)
    {
        return await context.Pies
            .Include(a => a.Category)
            .Include(v => v.Ingredients)
            .FirstOrDefaultAsync(a => a.PieId == id);
    }

    public async Task<int> AddPieAsync(Pie pie)
    {
        //throw new Exception("Database down");
        context.Pies.Add(pie);//could be done using async too
        return await context.SaveChangesAsync();
    }
}