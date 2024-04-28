using ExaminationSystem.Core.Bases;
using ExaminationSystem.Core.Features.Subject.Queries.Dtos;
using MediatR;

namespace ExaminationSystem.Core.Features.Subject.Queries.Models
{
    public class GetAllSubjectsForTeacherQuery : IRequest<Response<IReadOnlyList<GetSubjectDto>>>
    {
        public string TeacherId { get; set; }
    }
}
