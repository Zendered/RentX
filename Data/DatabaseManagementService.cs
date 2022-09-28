using Microsoft.EntityFrameworkCore;

namespace RentX.Data
{
    public static class DatabaseManagementService
    {
        public static void MigrationInitialisation(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var serviceDb = serviceScope.ServiceProvider.GetService<DataContext>();

            serviceDb?.Database.Migrate();
        }
    }
}
