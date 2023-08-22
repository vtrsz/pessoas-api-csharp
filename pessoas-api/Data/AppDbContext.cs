using Microsoft.EntityFrameworkCore;
using pessoas_api.Models;

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
