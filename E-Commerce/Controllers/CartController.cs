using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.services;
using ServiceLayer;
using ServiceLayer.ViewModels;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace E_Commerce.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartServices _cartServices;
        //private readonly ICa _cartServices;
        public CartController(ICartServices _cartServices)
        {
            this._cartServices = _cartServices;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetCart()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);



            return View(await _cartServices.GetById(userId));
        }
        [HttpPost]
        //  [ValidateAntiForgeryToken]
        [Route("Product/GetProduct/AddToCart")]
        public async Task<IActionResult> AddToCart(CartItemViewModel item)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await _cartServices.AddToCart(item, userId);

            return Json(new { isvalid = true });

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _cartServices.RemoveFromCart(userId, id);
            return Json(new {html= Helper.RenderRazorViewToString(this, "_allCartItems", await _cartServices.GetById(userId)) });
            

        }
    }
}
