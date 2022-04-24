using Ecommerce.DomainLayer.models;
using Ecommerce.RepositoryLayer.repositories;
using ServiceLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.services
{
    public class SupCategoryServices : ISupCategoryServices
    {
        private readonly IRepository<supcat> _supcatRepository;

        public SupCategoryServices(IRepository<supcat> repository)
        {
            _supcatRepository = repository;
        }
        #region Find By Id
        public async Task<SupCategoryViewModel> GetSupCategory(int id)
        {
            var SupCategory = await _supcatRepository.GetById(id);

            return new SupCategoryViewModel() { id = SupCategory.id, name = SupCategory.name };
        }
        #endregion
        #region Get All Sup Categories
        public async Task<IEnumerable<SupCategoryViewModel>> GetAllSUpCategories()
        {

            var AllSupCategory = await _supcatRepository.GetAll();
            return AllSupCategory.Select(x => new SupCategoryViewModel()
            {
                name = x.name,
                id = x.id
            });

        }
        #endregion
        #region Delete SupCategory
        public async Task DeleteSupCategory(int id)
        {
            await _supcatRepository.Delete(id);

        }
        #endregion
        #region Add New Sup Category
        public async Task AddSupCategory(SupCategoryViewModel supCategory)
        {
            supcat newsupcat = new() { id = supCategory.id, name = supCategory.name };

            await _supcatRepository.add(newsupcat);
        }
        #endregion
    }
}
