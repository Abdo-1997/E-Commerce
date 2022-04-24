using Ecommerce.DomainLayer.models;
using ServiceLayer.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface IProductService
    {
        Task<int> AddProduct(CreateProductViewModel newproduct);
        Task<ProductViewModel> GetById(int id);
         Task<IEnumerable<ProductViewModel>> GetProducts();
        IEnumerable<ProductViewModel> GetProductsByCategory(string category);
        Task RemoveProduct(int id);
    }
}