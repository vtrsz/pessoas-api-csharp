using Microsoft.EntityFrameworkCore;
using pessoas_api.Entities;

namespace pessoas_api.Data
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }

        public virtual DbSet<Person> People { get; set; }
    }
}
