using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.DomainLayer.models;
using Ecommerce.RepositoryLayer;
using Ecommerce.RepositoryLayer.repositories;
using ServiceLayer.ViewModels;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace ServiceLayer.services
{
    public class CartServices : ICartServices
    {
        #region Dependancy injection 
        private readonly IRepository<Cart> _cartrepository;
        private readonly IRepository<CartItems> _cartproductrepository;

        private readonly IRepository<Product> _productrepository;
        private readonly UserManager<ApplicationUser> _userManager;
        public CartServices(IRepository<Cart> repository, IRepository<Product> productrepository ,
            UserManager<ApplicationUser> userManager, IRepository<CartItems> cartproductrepository)
        {
            _cartrepository = repository;
            _productrepository = productrepository;
            _userManager = userManager;
            _cartproductrepository = cartproductrepository;
        }
        #endregion;


        #region Get All Carts
        public async Task<IEnumerable<Cart>> GetAll()
        {
            return await _cartrepository.GetAll();
        }
        #endregion

        #region get current user cart id 
    
        #endregion
        #region get cart items  by user id 
        public async  Task<IEnumerable<CartItemViewModel>> GetById(string id)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(id);
           
            IEnumerable<CartItems> cart = await _cartproductrepository.GetCartItemsAsync((int)user.cartid);

            IEnumerable<CartItemViewModel> cartitems = cart.Select(x => new CartItemViewModel()
            {
                productname = x.product.name,
                picture = x.product.pictures.picture1,
                productid = x.productId,
                productquantity = x.quantity,
                cartitemid = x.id,
                productPrice = x.product.price
            }); 


            return cartitems;
        }
        #endregion

        #region append item to cart
        public async Task AddToCart(CartItemViewModel cartItem, string userid)
        {
            Product product = await _productrepository.GetById(cartItem.productid);
         
            ApplicationUser user = await _userManager.FindByIdAsync(userid);
            CartItems cartItems = new() {
                product = product,
                quantity = cartItem.productquantity
            };


            if (user.cartid != null)
            {
                Cart cart = await _cartrepository.GetById(user.cartid);


                //get currnt user cart 
                if (cart == null)
                {

                    user.cart = new Cart();
                    var x = user.cart.cartItems.ToList();
                    x.Add(cartItems);
                    cart.cartItems = x;
                  

                }
                else
                {
                    var x = user.cart.cartItems.ToList();
                    x.Add(cartItems);
                    cart.cartItems = x;
                }
                //edit in data-base
                await _cartrepository.Update(cart);
            }


        }
        #endregion

        #region Remove Item From Cart
        public async Task RemoveFromCart(string userid, int productid)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(userid);
            Cart cart = await _cartrepository.GetById(user.cartid);
   
            IEnumerable<CartItems> cartItems = await _cartproductrepository.GetCartItemsAsync((int)user.cartid);
            if (cartItems.FirstOrDefault(x => x.cartId == user.cartid) != null)
            {
                await _cartproductrepository.Delete(productid);
            }
        }
        #endregion
    }
}
