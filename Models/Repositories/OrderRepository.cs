using Microsoft.EntityFrameworkCore;

namespace BethanysPieShopAdmin.Models.Repositories;

public class OrderRepository(BethanysPieShopDbContext context) : IOrderRepository
{
    public async Task<Order?> GetOrderDetailsAsync(int? orderId)
    {
        if (orderId == null)
        {
            return null;
        }
        return await context.Orders
            .Include(a => a.OrderDetails)
            .ThenInclude(a => a.Pie)
            .OrderBy(a => a.OrderId)
            .Where(a=> a.OrderId == orderId.Value)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Order>> GetAllOrdersWithDetailsAsync()
    {
        return await context.Orders.Include(a => a.OrderDetails)
            .ThenInclude(a => a.Pie)
            .OrderBy(a => a.OrderId)
            .ToListAsync();
    }
}