using ExaminationSystem.Core.Bases;
using ExaminationSystem.Core.Features.Questions.Queries.Dtos;
using MediatR;

namespace ExaminationSystem.Core.Features.Questions.Queries.Models
{
    public class GetAllQuestionsForExamQuery : IRequest<Response<IReadOnlyList<GetQuestionWithAnswersDto>>>
    {
        public int ExamId { get; set; }
    }
}
