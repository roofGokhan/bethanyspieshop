using BethanysPieShopAdmin.Models;
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
        if (id == null) return NotFound();
        if (category == null) return NotFound();
        CategoryListViewModel model = new()
        {
            Categories = (await _categoryRepository.GetCategoriesAsync()).ToList(),
            Category = category
        };
        return View(model.Category);
    }

    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add([Bind("Name,Description,DateAdded")] Category category)
    {
        try
        {
            if (ModelState.IsValid)
            {
                await _categoryRepository.AddCategoryAsync(category);
                return RedirectToAction(nameof(Index));
            }
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", $"Adding the category failed, please try again! Error: {ex.Message}");
        }

        return View(category);
    }
}