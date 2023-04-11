using Microsoft.EntityFrameworkCore;

namespace HCMS.data
{
    public static class AutoMigration
    {
        public static void Automigrate(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                using (var appContext = scope.ServiceProvider.GetRequiredService<HCMSDbContext>())
                {
                    try
                    {
                        appContext.Database.Migrate(); // migration are there in the assembly update them on the database.
                    }
                    catch (Exception ex)
                    {
                        //Log errors or do anything you think it's needed
                        throw;
                    }
                }
            }
        }
    }
}
