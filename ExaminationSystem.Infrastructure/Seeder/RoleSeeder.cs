using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace ExaminationSystem.Infrastructure.Seeder
{
    public class RoleSeeder
    {
        public static async Task SeedAsync(RoleManager<IdentityRole> roleManager, ILoggerFactory loggerFactory)
        {
            try
            {

                var rolesCount = await roleManager.Roles.CountAsync();
                if (rolesCount == 0)
                {
                    var rolesData = File.ReadAllText("../ExaminationSystem.Infrastructure/SeedData/Role.json");
                    var roles = JsonSerializer.Deserialize<List<IdentityRole>>(rolesData);
                    if (roles != null)
                    {
                        foreach (var role in roles)
                        {
                            await roleManager.CreateAsync(role);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<RoleSeeder>();
                logger.LogError(e.Message);
            }
        }
    }
}
