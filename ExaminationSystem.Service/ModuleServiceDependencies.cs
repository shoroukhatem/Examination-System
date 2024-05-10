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
            services.AddTransient<ISubjectService, SubjectService>();
            services.AddTransient<IExamService, ExamService>();
            services.AddTransient<IQuestionService, QuestionService>();
            services.AddTransient<IAnswerService, AnswerService>();
            return services;
        }

    }
}
