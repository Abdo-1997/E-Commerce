using Ecommerce.DomainLayer.models;
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
        #region Add
        public async Task< int> add(T obj)
        {
            entities.Add(obj);
            return await _applicationDbContext.SaveChangesAsync();
        }
        #endregion

        #region Get All
        public async Task<IEnumerable<T>> GetAll()
        {
            return await entities.ToListAsync();
        }
        #endregion

        #region Get By Id
        public async Task< T> GetById(int? id)
        {
            return await entities.FindAsync(id);

        }
        #endregion

        #region Delete
        public async Task Delete(int id)
        {

            T x =await entities.FindAsync(id);
             entities.Remove(x);
            _applicationDbContext.SaveChanges();
        }
        #endregion

        #region Get BY category 
        public IQueryable<Product> GetByCategory(string category)
        {
            var cat = _applicationDbContext.maincats.FirstOrDefault(x => x.name == category);
            IQueryable<Product> products= _applicationDbContext.products.Where(x => x.maincat.id == cat.id);
            return products;
        }
        #endregion

        #region update 
        public async Task<int> Update(T entity)
        {
            entities.Update(entity);
           return await _applicationDbContext.SaveChangesAsync();
        }
        #endregion

        #region Get Cart Items By User Id
        public async Task<IEnumerable<CartItems>> GetCartItemsAsync(int id)
        {
            return await _applicationDbContext.cartitems.Where(x => x.cartId == id).ToListAsync();
        }
        #endregion
    }
}
