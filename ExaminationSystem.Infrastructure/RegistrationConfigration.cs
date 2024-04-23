using ExaminationSystem.Domain.Entities;
using ExaminationSystem.Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Infrastructure
{
    public static class RegistrationConfigration
    {
        public static IServiceCollection AddRegistrationConfigration(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                //password Settings
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 8;
                //Lockout Settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;
                //user settings
                options.SignIn.RequireConfirmedAccount = false;
            }).AddEntityFrameworkStores<ExamSystemDbContext>().AddDefaultTokenProviders();
            return services;
        }
    }
}
