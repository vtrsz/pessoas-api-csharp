using Microsoft.EntityFrameworkCore;
using pessoas_api.Entities;

namespace pessoas_api.Repositories
{
    public class PersonRepository : Repository<Person>
    {
        public PersonRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public new Task<Person?> GetByIdAsync(long id)
        {
            return _entity.Include(p => p.Addresses) // Include related Addresses
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public new Task<List<Person>> GetAllAsync()
        {
            return _entity.Include(p => p.Addresses).ToListAsync();
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
