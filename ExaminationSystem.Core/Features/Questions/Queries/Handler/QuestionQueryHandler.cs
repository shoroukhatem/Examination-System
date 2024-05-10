using AutoMapper;
using ExaminationSystem.Core.Bases;
using ExaminationSystem.Core.Features.Questions.Queries.Dtos;
using ExaminationSystem.Core.Features.Questions.Queries.Models;
using ExaminationSystem.Service.Abstracts;
using MediatR;

namespace ExaminationSystem.Core.Features.Questions.Queries.Handler
{
    public class QuestionQueryHandler : ResponseHandler, IRequestHandler<GetAllQuestionsForExamQuery, Response<IReadOnlyList<GetQuestionWithAnswersDto>>>
    {
        #region Fields
        private readonly IMapper _Mapper;
        private readonly IQuestionService _QuestionService;
        private readonly IAnswerService _AnswerService;


        #endregion
        #region Constructor
        public QuestionQueryHandler(IMapper mapper, IQuestionService questionService, IAnswerService answerService)
        {
            _Mapper = mapper;
            _QuestionService = questionService;
            _AnswerService = answerService;
        }
        #endregion
        #region Handlers
        //Get Questions With thier Answers
        public async Task<Response<IReadOnlyList<GetQuestionWithAnswersDto>>> Handle(GetAllQuestionsForExamQuery request, CancellationToken cancellationToken)
        {
            //Getting All the Exam Questions
            var QuestionList = await _QuestionService.GetAllQuestionsForEachExamAsync(request.ExamId);
            List<GetQuestionWithAnswersDto> questionsWithThierAnswers = new List<GetQuestionWithAnswersDto>();
            foreach (var question in QuestionList)
            {

                GetQuestionWithAnswersDto getQuestionWithAnswers = _Mapper.Map<GetQuestionWithAnswersDto>(question);
                if (question.QuestionType == "MCQ")
                {
                    //Getting Answers for Each Exam
                    getQuestionWithAnswers.Answers = await _AnswerService.GetListofAnswersForQuestionAsync(question.Id);
                }
                /*  else
                  {
                      var AnswerForThisQuestion = { };

                  }*/
                //Map Question To GetQuestionWithAnswersDto

                questionsWithThierAnswers.Add(getQuestionWithAnswers);
            }
            IReadOnlyList<GetQuestionWithAnswersDto> Questions = questionsWithThierAnswers.AsReadOnly();
            return Success<IReadOnlyList<GetQuestionWithAnswersDto>>(Questions);
        }
        #endregion
    }
}
