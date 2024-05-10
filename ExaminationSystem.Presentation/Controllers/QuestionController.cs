using ExaminationSystem.Core.Features.Questions.Commands.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.Presentation.Controllers
{
    public class QuestionController : BaseController
    {

        #region Constructor
        public QuestionController(IMediator mediator) : base(mediator)
        {

        }

        #endregion
        #region Actions
        //public async Task<IActionResult> IndexAsync(int ExamId)
        //{
        //    var result = await _Mediator.Send(new GetAllQuestionsForExamQuery() { ExamId = ExamId });
        //    return View(result.Data);
        //}
        public IActionResult Create(int ExamId, string QuestionType)
        {
            ViewData["ExamId"] = ExamId;
            ViewData["QuestionType"] = QuestionType;
            if (QuestionType == "MCQ")
            {
                return View("CreateMCQ", new AddQuestionCommand() { QuestionType = QuestionType });
            }
            return View("CreateTOrF", new AddQuestionCommand() { QuestionType = QuestionType });
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddQuestionCommand question)
        {
            if (ModelState.IsValid)
            {
                var result = _Mediator.Send(question);
                if (result.Result.Succeeded)
                {
                    if (question.QuestionType == "MCQ")
                    {
                        for (int i = 0; i < question.AnswersAndCorrect.Answers.Count; i++)
                        {
                            question.AnswersAndCorrect.Answers[i].QuestionId = result.Result.Data;
                        }
                        var answerResult = _Mediator.Send(question.AnswersAndCorrect);
                        await Console.Out.WriteLineAsync(answerResult.Result.Message);
                    }
                    RedirectToAction("ExamPaper", "Exams", new { ExamId = question.ExamId });

                }
                else
                {
                    return View($"Create{question.QuestionType}", question);
                }
            }
            return View($"Create{question.QuestionType}", question);
        }
        // var answers = questionViewModel.Answers;
        //  var resultForAddingAnswers = _Mediator.Send(answers);
        #endregion
    }

}
