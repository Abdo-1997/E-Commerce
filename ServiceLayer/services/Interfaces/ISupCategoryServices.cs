using ServiceLayer.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer.services
{
    public interface ISupCategoryServices
    {
        Task AddSupCategory(SupCategoryViewModel supCategory);
        Task DeleteSupCategory(int id);
        Task<IEnumerable<SupCategoryViewModel>> GetAllSUpCategories();
        Task<SupCategoryViewModel> GetSupCategory(int id);
    }
}