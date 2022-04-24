using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceLayer;
using ServiceLayer.services;
using ServiceLayer.ViewModels;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace E_Commerce.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productservice;
        private readonly IMainCategoryServices _mainCategoryServices;
        private readonly ISupCategoryServices _SupCategoryServices;
     
        public ProductController(IProductService productservice ,IMainCategoryServices mainCategoryServices, ISupCategoryServices supCategoryServices)
        {
            _productservice = productservice;
            _mainCategoryServices = mainCategoryServices;
            _SupCategoryServices = supCategoryServices;
    }
    public async Task<IActionResult> Index()

        {
           IEnumerable<ProductViewModel> product=await _productservice.GetProducts();
            HttpContext.Session.SetInt32("session",20);
            
            return View(product);
        }
        public async Task<IActionResult> CreateProduct()
        {
            ViewData["MainCategory"] = new SelectList(await _mainCategoryServices.GetAllMainCategory(), "id", "name");
            ViewData["SupCategory"] = new SelectList(await _SupCategoryServices.GetAllSUpCategories(), "id", "name");
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromForm]CreateProductViewModel productViewModel)
        {
            
            await _productservice.AddProduct(productViewModel);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> GetProduct(int id)
        {
            ProductViewModel product = await _productservice.GetById(id);
            return View(product);

        }

        public async Task<IActionResult> RemoveProduct(int id)
        {
            await _productservice.RemoveProduct(id);
            return View();
        }
        #region Find by category
        public  IActionResult GetByCategory(string category)
        {
          IEnumerable<ProductViewModel> products =   _productservice.GetProductsByCategory(category);
            return View(nameof(Index), products);
        }
        #endregion
    }
}
