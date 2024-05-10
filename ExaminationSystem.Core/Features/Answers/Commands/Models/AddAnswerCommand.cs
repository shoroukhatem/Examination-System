using ExaminationSystem.Core.Bases;
using ExaminationSystem.Core.Features.Answers.Commands.Dtos;
using MediatR;

namespace ExaminationSystem.Core.Features.Answers.Commands.Models
{
    public class AddAnswersCommand : IRequest<Response<string>>
    {
        public List<AnswerDto>? Answers { get; set; }
        public int TrueAnswer { get; set; }
    }
}
