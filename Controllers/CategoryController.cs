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
    
    public async Task<IActionResult> Details(int? id)
    {
        var category = await _categoryRepository.GetCategoryAsync(id);
        if (id == null)
        {
            return NotFound();
        }
        if (category == null)
        {
            return NotFound();
        }
        CategoryListViewModel model = new()
        {
            Categories = (await _categoryRepository.GetCategoriesAsync()).ToList(),
            Category = category
        };
        return View(model.Category);
        
        
    }
}

