using ExaminationSystem.Infrastructure.Repository.Implementation;
using ExaminationSystem.Infrastructure.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Store.Repository.Repositories;

namespace ExaminationSystem.Infrastructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            //services.AddScoped<IGenericRepository, GenericRepository<,>>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
