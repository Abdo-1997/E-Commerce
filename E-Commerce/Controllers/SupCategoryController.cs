using Microsoft.AspNetCore.Mvc;
using ServiceLayer.services;
using ServiceLayer.ViewModels;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Commerce.Controllers
{
    public class SupCategoryController : Controller
    {
        private readonly ISupCategoryServices _supCategoryServices;
        public SupCategoryController(ISupCategoryServices supCategoryServices)
        {
            _supCategoryServices = supCategoryServices;
        }
        public async Task< IActionResult> Index()
        {
            IEnumerable<SupCategoryViewModel> allsupcategory = await _supCategoryServices.GetAllSUpCategories(); 
            return View(allsupcategory);
        }

        public async Task<IActionResult> Create(SupCategoryViewModel newsupcategory)
        {
            if (ModelState.IsValid) { 
            await _supCategoryServices.AddSupCategory(newsupcategory);
                return RedirectToAction(nameof(Index));
            }
            return View("index", await _supCategoryServices.GetAllSUpCategories());
        }  
    }
}
