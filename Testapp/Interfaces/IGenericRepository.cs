using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Testapp.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        Task<List<T>> GetListAsync(
           Expression<Func<T, bool>> condition);
    }
}
