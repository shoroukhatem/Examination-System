using ExaminationSystem.Core.Bases;
using MediatR;

namespace ExaminationSystem.Core.Features.Questions.Commands.Models
{
    public class AddTOrFQuestionCommand : AddQuestionCommand, IRequest<Response<int>>
    {


    }
}
