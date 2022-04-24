using Ecommerce.DomainLayer.models;
using ServiceLayer.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface IProductService
    {
        Task<int> AddProduct(CreateProductViewModel newproduct);
        Task<ProductViewModel> GetById(int id);
         Task<IEnumerable<ProductViewModel>> GetProducts();
        Task RemoveProduct(int id);
    }
}