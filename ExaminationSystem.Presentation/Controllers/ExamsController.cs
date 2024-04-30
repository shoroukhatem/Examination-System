using ExaminationSystem.Core.Features.Exams.Commands.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.Presentation.Controllers
{
    public class ExamsController : Controller
    {
        private readonly IMediator _Mediator;

        public ExamsController(IMediator mediator)
        {
            _Mediator = mediator;
        }
        public IActionResult Index()
        {
            return View();
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
            examDto.TeacherId = TempData["TeacherId"].ToString();
            examDto.SubjectId = (int)TempData["SubjectId"];
            //  if (ModelState.IsValid)
            // {
            var response = _Mediator.Send(examDto);
            if (response.Result.Succeeded)
            {
                return RedirectToAction("Exams", "Subject", new { SubjectId = examDto.SubjectId, TeacherId = examDto.TeacherId });
            }
            // }
            return View(examDto);
        }
    }
}
