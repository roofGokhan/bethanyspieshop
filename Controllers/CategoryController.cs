using BethanysPieShopAdmin.Models.Repositories;
using BethanysPieShopAdmin.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShopAdmin.Controllers;

public class CategoryController : Controller
{
    private readonly ICategoryRepository _categoryRepository;
    public CategoryController(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    // GET
    public async Task<IActionResult> Index()
    {
        CategoryListViewModel model = new()
        {
            Categories = (await _categoryRepository.GetCategoriesAsync()).ToList()
        };
        return View(model);
    }
}

