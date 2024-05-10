using ExaminationSystem.Core.Features.Exams.Commands.Models;
using ExaminationSystem.Core.Features.Exams.Queries.Models;
using ExaminationSystem.Core.Features.Questions.Queries.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.Presentation.Controllers
{
    public class ExamsController : BaseController
    {


        public ExamsController(IMediator mediator) : base(mediator)
        {

        }

        public IActionResult Index(int ExamId)
        {
            var exam = _Mediator.Send(new GetExamQuery { ExamId = ExamId });
            return View(exam);
        }
        public async Task<IActionResult> ExamPaper(int ExamId)
        {
            ViewData["ExamId"] = ExamId;
            var result = await _Mediator.Send(new GetAllQuestionsForExamQuery() { ExamId = ExamId });
            return View(result.Data);
        }

        [Authorize(Roles = "Teacher")]
        public IActionResult Create(int SubjectId, string TeacherId)
        {
            return View(new AddExamCommand() { SubjectId = SubjectId, TeacherId = TeacherId });
        }
        [Authorize(Roles = "Teacher")]
        [HttpPost]
        public IActionResult Create(AddExamCommand examDto)
        {
            if (ModelState.IsValid)
            {
                var response = _Mediator.Send(examDto);
                if (response.Result.Succeeded)
                {
                    return RedirectToAction("Exams", "Subject", new { SubjectId = examDto.SubjectId, TeacherId = examDto.TeacherId });
                }
            }
            return View(examDto);
        }
    }
}
