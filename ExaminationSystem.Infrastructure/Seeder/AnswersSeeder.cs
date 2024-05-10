using ExaminationSystem.Infrastructure.Context;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace ExaminationSystem.Infrastructure.Seeder
{
    public class AnswersSeeder
    {
        public static async Task SeedAsync(ExamSystemDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {

                var answersCount = context.Answers.Count();
                if (answersCount == 0)
                {
                    var answersData = File.ReadAllText("../ExaminationSystem.Infrastructure/SeedData/Answers.json");
                    var answers = JsonSerializer.Deserialize<List<Answer>>(answersData);
                    if (answers != null)
                    {
                        foreach (var answer in answers)
                        {
                            await context.Answers.AddAsync(answer);
                        }
                        await context.SaveChangesAsync();
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
