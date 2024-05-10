using AutoMapper;
using ExaminationSystem.Core.Bases;
using ExaminationSystem.Core.Features.Questions.Commands.Models;
using ExaminationSystem.Service.Abstracts;
using MediatR;

namespace ExaminationSystem.Core.Features.Questions.Commands.Handler
{
    public class QuestionCommandHandler : ResponseHandler, IRequestHandler<AddQuestionCommand, Response<int>>
    {

        #region Fields
        private readonly IMapper _Mapper;
        private readonly IQuestionService _QuestionService;

        #endregion
        #region Constructor
        public QuestionCommandHandler(IMapper mapper, IQuestionService questionService)
        {
            _Mapper = mapper;
            _QuestionService = questionService;
        }
        #endregion
        #region Handle Functions
        public async Task<Response<int>> Handle(AddQuestionCommand request, CancellationToken cancellationToken)
        {

            if (request.QuestionType == "TOrF")
            {

                var question = _Mapper.Map<TOrF>(request);
                question.TrueAnswer = request.AnswersAndCorrect.TrueAnswer;
                var result = await _QuestionService.AddAsync(question);
                if (result != -1)
                {
                    return Created(result);
                }
                return BadRequest<int>("Failed");
            }
            else
            {
                var question = _Mapper.Map<MCQ>(request);
                var result = await _QuestionService.AddAsync(question);
                if (result != -1)
                {
                    return Created(result);
                }
                return BadRequest<int>("Failed");
            }
        }
        //Adding TOrF Question
        #endregion
    }
}
