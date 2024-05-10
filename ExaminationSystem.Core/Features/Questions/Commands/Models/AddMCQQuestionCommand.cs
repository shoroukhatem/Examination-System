using ExaminationSystem.Core.Bases;
using ExaminationSystem.Core.Features.Answers.Commands.Dtos;
using MediatR;

namespace ExaminationSystem.Core.Features.Questions.Commands.Models
{
    public class AddMCQQuestionCommand : AddQuestionCommand, IRequest<Response<int>>
    {

        public List<AnswerDto> Answers { get; set; }
    }
}
