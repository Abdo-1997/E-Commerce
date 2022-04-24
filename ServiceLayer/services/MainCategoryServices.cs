using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.RepositoryLayer.repositories;
using Ecommerce.DomainLayer.models;
using ServiceLayer.ViewModels;


namespace ServiceLayer.services
{
    public class MainCategoryServices : IMainCategoryServices
    {
        private readonly IRepository<maincat> _maincategoryrepo;
        public MainCategoryServices(IRepository<maincat> maincatrepository)
        {
            _maincategoryrepo = maincatrepository;
        }
        public async Task<IEnumerable<CategoryViewModel>> GetAllMainCategory()
        {
            var result =await _maincategoryrepo.GetAll();
            IEnumerable<CategoryViewModel> x=result.Select(x => new CategoryViewModel()
            {
                id = x.id,
                name = x.name
            });
            return x;
        }
        public async Task<int> AddMainCategory(CategoryViewModel category)
        {
            maincat newmaincat = new()
            {
                name = category.name
            };
            return await _maincategoryrepo.add(newmaincat);
        }
        public async Task Delete(int id)
            
        {
           
                await _maincategoryrepo.Delete(id);
            
         
        }

    }
}
