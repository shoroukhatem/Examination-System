using ExaminationSystem.Core.Features.Answers.Commands.Dtos;
using ExaminationSystem.Core.Features.Answers.Commands.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.Presentation.Controllers
{
    public class AnswersController : BaseController
    {
        #region Constructor
        public AnswersController(IMediator mediator) : base(mediator)
        {
        }

        #endregion
        #region Actions
        public IActionResult Create(string QuestionType, int QuestionId)
        {
            ViewData["QuestionId"] = QuestionId;
            if (QuestionType == "MCQ")
            {
                return View(new AddAnswersCommand() { Answers = new List<AnswerDto>(4) });
            }
            else if (QuestionType == "TOrF")
            {
                return View(new AddAnswersCommand() { Answers = null });
            }
            return View();
        }
        [HttpPost]
        public IActionResult Create(AddAnswersCommand addAnswersCommand)
        {
            if (ModelState.IsValid)
            {
                var result = _Mediator.Send(addAnswersCommand);
                if (result.Result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(addAnswersCommand);
        }

        #endregion

    }
}
