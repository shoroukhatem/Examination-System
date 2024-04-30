using ExaminationSystem.Core.Bases;
using ExaminationSystem.Core.Features.Exams.Queries.Dtos;
using MediatR;

namespace ExaminationSystem.Core.Features.Exams.Queries.Models
{
    public class GetAllExamsDetailsForEachSubjectQuery : IRequest<Response<IReadOnlyList<GetExamHeadLinesDto>>>
    {
        public int SubjectId { get; set; }
    }

}
