using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.RepositoryLayer.repositories
{
    public interface IRepository<T>
    {
        Task<int> add(T obj);
        Task Delete(int id);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
    }
}