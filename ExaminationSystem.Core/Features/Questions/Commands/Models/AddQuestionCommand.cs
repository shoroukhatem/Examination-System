using ExaminationSystem.Core.Bases;
using ExaminationSystem.Core.Features.Answers.Commands.Models;
using MediatR;

namespace ExaminationSystem.Core.Features.Questions.Commands.Models
{
    public class AddQuestionCommand : IRequest<Response<int>>
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public double Mark { get; set; }
        public int ExamId { get; set; }
        public string QuestionType { get; set; }
        public AddAnswersCommand AnswersAndCorrect { get; set; }
    }
}
