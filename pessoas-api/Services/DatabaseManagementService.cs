using Microsoft.EntityFrameworkCore;
using pessoas_api.Data;

namespace pessoas_api.Services
{
    public static class DatabaseManagementService
    {
        public static void InitializeMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var serviceDb = serviceScope.ServiceProvider.GetService<AppDbContext>();
                serviceDb.Database.Migrate();
            }
        }
    }
}
