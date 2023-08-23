using Microsoft.EntityFrameworkCore;
using pessoas_api.Entities;

namespace pessoas_api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Person> People { get; set; }
    }
}
