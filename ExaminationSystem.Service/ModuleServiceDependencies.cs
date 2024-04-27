using ExaminationSystem.Service.Abstracts;
using ExaminationSystem.Service.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace ExaminationSystem.Service
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            return services;
        }
    }
}
