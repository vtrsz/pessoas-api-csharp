using System.Linq.Expressions;
using pessoas_api.Entities;

namespace pessoas_api.Repositories
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task<int> AddAsync(T item);
        Task<List<T>> GetAsync(Expression<Func<T, bool>> predicate);
        Task<T?> GetByIdAsync(long id);
        Task<List<T>> GetAllAsync();
        Task<int> UpdateAsync(T item);
        Task<int> DeleteAsync(T item);
    }
}