using Ecommerce.DomainLayer.models;
using ServiceLayer.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer.services
{
    public interface ICartServices
    {
        Task AddToCart(CartItemViewModel cartItem, string cartid);
        Task<IEnumerable<Cart>> GetAll();
        Task<IEnumerable<CartItemViewModel>> GetById(string id);
        Task RemoveFromCart(string userid, int productid);
    }
}