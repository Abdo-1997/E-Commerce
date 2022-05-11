using Ecommerce.DomainLayer.models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.RepositoryLayer.repositories
{
    public interface IRepository<T>
    {
        Task<int> add(T obj);
        Task Delete(int id);
        Task<IEnumerable<T>> GetAll();
        IQueryable<Product> GetByCategory(string category);
        Task<T> GetById(int? id);
        Task< IEnumerable<CartItems>> GetCartItemsAsync(int id);
        Task<int> Update(T entity);
    }
}