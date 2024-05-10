using AutoMapper;
using ExaminationSystem.Core.Bases;
using ExaminationSystem.Core.Features.Answers.Commands.Models;
using ExaminationSystem.Service.Abstracts;
using MediatR;

namespace ExaminationSystem.Core.Features.Answers.Commands.Handler
{
    public class AnswerCommandHandler : ResponseHandler, IRequestHandler<AddAnswersCommand, Response<string>>
    {

        #region Fields
        private readonly IMapper _Mapper;
        private readonly IQuestionService _QuestionService;
        private readonly IAnswerService _AnswerService;


        #endregion
        #region Constructor
        public AnswerCommandHandler(IMapper mapper, IQuestionService questionService, IAnswerService answerService)
        {
            _Mapper = mapper;
            _QuestionService = questionService;
            _AnswerService = answerService;
        }
        #endregion
        #region Handle Functions
        public async Task<Response<string>> Handle(AddAnswersCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var answers = _Mapper.Map<List<Answer>>(request.Answers);
                var result = await _AnswerService.AddListofAnswers(answers);
                var question = await _QuestionService.GetQuestionByIdAsync(answers[0].QuestionId.Value);
                question.TrueAnswer = result[(request.TrueAnswer - 1)];
                int Affectedrows = await _QuestionService.UpdateAsync(question);
                if (result.Count > 0 && Affectedrows > 0)
                {
                    return Created("");
                }
                return BadRequest<string>("Failed");
            }
            catch (Exception ex)
            {
                return BadRequest<string>(ex.Message);
            }
        }
        #endregion
    }
}
