using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using pessoas_api.Entities;

namespace pessoas_api.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly DbContext _context;
        protected readonly DbSet<T> _entity;

        public Repository(DbContext dbContext)
        {
            _context = dbContext;
            _entity = _context.Set<T>();
        }

        public Task<int> AddAsync(T item)
        {
            _entity.AddAsync(item);
            return _context.SaveChangesAsync();
        }

        public Task<List<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return _entity.Where(predicate).ToListAsync();
        }

        public Task<T?> GetByIdAsync(long id)
        {
            return _entity.FirstOrDefaultAsync(t => t.Id == id);
        }

        public Task<List<T>> GetAllAsync()
        {
            return _entity.ToListAsync();
        }

        public Task<int> UpdateAsync(T item)
        {
            _context.Update(item);
            return _context.SaveChangesAsync();
        }

        public Task<int> DeleteAsync(T item)
        {
            _entity.Remove(item);
            return _context.SaveChangesAsync();
        }
    }
}
