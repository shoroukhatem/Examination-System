using ExaminationSystem.Infrastructure.Context;
using ExaminationSystem.Infrastructure.Seeder;
using Microsoft.AspNetCore.Identity;

namespace ExaminationSystem.Presentation.Helper
{
    public class ApplySeeding
    {
        public static async Task ApplySeedingAsync(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                var context = services.GetRequiredService<ExamSystemDbContext>();
                try
                {
                    await RoleSeeder.SeedAsync(roleManager, loggerFactory);
                    await AnswersSeeder.SeedAsync(context, loggerFactory);

                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<ApplySeeding>();
                    logger.LogError(ex.Message);
                }
            }
        }
    }
}
