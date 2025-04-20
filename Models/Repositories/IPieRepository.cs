namespace BethanysPieShopAdmin.Models.Repositories;

public interface IPieRepository
{
    Task<List<Pie>> GetPiesAsync();
    Task<Pie?> GetPieAsync(int? id);
    Task<int> AddPieAsync(Pie pie);
}