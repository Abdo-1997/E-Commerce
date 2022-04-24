using Ecommerce.DomainLayer.models;
using ServiceLayer.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer.services
{
    public interface IMainCategoryServices
    {
        Task<int> AddMainCategory(CategoryViewModel category);
        Task Delete(int id);
      
        Task<IEnumerable<CategoryViewModel>> GetAllMainCategory();
    }
}