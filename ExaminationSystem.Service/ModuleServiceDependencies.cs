using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Service
{
    internal class ModuleServiceDependencies
    {
<<<<<<< Updated upstream
=======
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<ISubjectService, SubjectService>();
            return services;
        }
>>>>>>> Stashed changes
    }
}
