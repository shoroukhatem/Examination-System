using ExaminationSystem.Service.Abstracts;
using ExaminationSystem.Service.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace ExaminationSystem.Service
{
    public static class ModuleServiceDependencies
    {
<<<<<<< HEAD
<<<<<<< Updated upstream
=======
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<ISubjectService, SubjectService>();
            return services;
        }
>>>>>>> Stashed changes
=======
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            return services;
        }
>>>>>>> b9f51f04124c0a547b06717ea4f44c4be383cfd1
    }
}
