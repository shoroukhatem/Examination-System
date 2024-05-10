using ExaminationSystem.Core.Bases;
using ExaminationSystem.Core.Features.Exams.Queries.Dtos;
using MediatR;

namespace ExaminationSystem.Core.Features.Exams.Queries.Models
{
    public class GetExamQuery : IRequest<Response<GetExamDto>>
    {
        public int ExamId { get; set; }
    }
}
