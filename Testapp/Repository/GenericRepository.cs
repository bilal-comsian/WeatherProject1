using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using Testapp.Interfaces;

namespace Testapp.Repository
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly MyDbContext _dbContext;

        protected GenericRepository(MyDbContext context)
        {
            _dbContext = context;
        }

        public async Task<T> GetById(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }
        public async Task<List<T>> GetListAsync(
           Expression<Func<T, bool>> condition)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (condition != null)
            {
                query = query.Where(condition);
            }

            //if (includes != null)
            //{
            //    query = includes(query);
            //}

            //if (asNoTracking)
            //{
            //    query = query.AsNoTracking();
            //}

            List<T> entities = await query.ToListAsync();

            return entities;
        }
        public async Task Add(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }
    }
}
