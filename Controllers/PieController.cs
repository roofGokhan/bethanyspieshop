using BethanysPieShopAdmin.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShopAdmin.Controllers;

public class PieController(IPieRepository pieRepository) : Controller
{

    // GET
    public async Task<IActionResult> Index()
    {
        var list = await pieRepository.GetPiesAsync();
        return View(list);
    }
    public async Task<IActionResult> Details(int? id)
    {
        var pie = await pieRepository.GetPieAsync(id);
        if (id == null)
        {
            return NotFound();
        }
        if (pie == null)
        {
            return NotFound();
        }
        return View(pie);
    }
}