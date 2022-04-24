using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.RepositoryLayer.repositories
{
    public class Repository<T> : IRepository<T> where T :class
    {
        private readonly DataContext _applicationDbContext;
        private DbSet<T> entities;

        public Repository(DataContext dbContext)
        {
            _applicationDbContext = dbContext;
            entities = dbContext.Set<T>();

        }
        public async Task< int> add(T obj)
        {
            entities.Add(obj);
            return await _applicationDbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await entities.ToListAsync();
        }
        public async Task< T> GetById(int id)
        {
            return await entities.FindAsync(id);

        }
        public async Task Delete(int id)
        {

            T x =await entities.FindAsync(id);
             entities.Remove(x);
            _applicationDbContext.SaveChanges();
        }
    }
}
