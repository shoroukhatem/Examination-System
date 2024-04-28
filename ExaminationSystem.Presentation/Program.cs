using ExaminationSystem.Core;
using ExaminationSystem.Infrastructure;
using ExaminationSystem.Infrastructure.Context;
using ExaminationSystem.Presentation.Helper;
using ExaminationSystem.Service;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSystem.Presentation
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ExamSystemDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            #region Dependency Injection

<<<<<<< HEAD
<<<<<<< Updated upstream
            builder.Services.AddCoreDependencies().AddRegistrationConfigration();
=======
            builder.Services.AddServiceDependencies()
                .AddCoreDependencies()
                .AddInfrastructureDependencies()
                .AddRegistrationConfigration(builder.Configuration);
>>>>>>> Stashed changes
=======
            builder.Services.AddServiceDependencies().AddCoreDependencies().AddRegistrationConfigration(builder.Configuration);
>>>>>>> b9f51f04124c0a547b06717ea4f44c4be383cfd1
            #endregion
            var app = builder.Build();
            //Appling Seeding
            await ApplySeeding.ApplySeedingAsync(app);
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=User}/{action=SignIn}/{id?}");

            app.Run();
        }
    }
}