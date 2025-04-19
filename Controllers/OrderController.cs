using BethanysPieShopAdmin.Models;
using BethanysPieShopAdmin.Models.Repositories;
using BethanysPieShopAdmin.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShopAdmin.Controllers;

public class OrderController(IOrderRepository orderRepository) : Controller
{
    // GET
    public async Task<IActionResult> Index(int? orderId, int? orderDetailId)
    {
        OrderIndexViewModel orderIndexViewModel = new OrderIndexViewModel()
        {
            Orders = await orderRepository.GetAllOrdersWithDetailsAsync()
        };
        if (orderId != null)
        {
            var selectedOrder = orderIndexViewModel.Orders.Where(o=> o.OrderId == orderId).Single();
            orderIndexViewModel.SelectedOrderId = orderId;
            orderIndexViewModel.OrderDetails = selectedOrder.OrderDetails;
        }
        if (orderDetailId != null)
        {
            var selectedOrderDetail = orderIndexViewModel.OrderDetails.Where(od => od.OrderDetailId == orderDetailId).Single();
            orderIndexViewModel.SelectedOrderDetailId = orderDetailId;
            orderIndexViewModel.Pies = new List<Pie>()
            {
                selectedOrderDetail.Pie
            };
        }
        return View(orderIndexViewModel);
    }
    
    public async Task<IActionResult> Details(int? orderId)
    {
        
        var order = await orderRepository.GetOrderDetailsAsync(orderId);
        
        return View(order);
    }
}