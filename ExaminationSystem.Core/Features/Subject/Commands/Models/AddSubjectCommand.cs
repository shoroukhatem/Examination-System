using ExaminationSystem.Core.Bases;
using MediatR;

namespace ExaminationSystem.Core.Features.Subject.Commands.Models
{
    public class AddSubjectCommand : IRequest<Response<string>>
    {
        public string Name { get; set; }
        public string TeacherId { get; set; }
    }
}
