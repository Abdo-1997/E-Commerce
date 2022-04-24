using Microsoft.AspNetCore.Mvc;
using ServiceLayer.services;
using ServiceLayer.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Commerce.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IMainCategoryServices _categoryServices;
        public CategoryController(IMainCategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }
        public async Task<IActionResult> Index()
        {
            var x = await _categoryServices.GetAllMainCategory();
            IEnumerable<CategoryViewModel> categories =x;
            return View(categories);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Create(CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                await _categoryServices.AddMainCategory(category);
                return RedirectToAction(nameof(Index));
            }else
            {
                return View(nameof(Index), category);
            }
        }
        public async Task<IActionResult> Delete(int id) {
            await _categoryServices.Delete(id);
            return RedirectToAction(nameof(Index));
        
        }


    }
}
