using ExaminationSystem.Core.Features.Exams.Queries.Models;
using ExaminationSystem.Core.Features.Subject.Commands.Models;
using ExaminationSystem.Core.Features.Subject.Queries.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.Presentation.Controllers
{
    public class SubjectController : Controller
    {
        private readonly IMediator _Mediator;

        public SubjectController(IMediator mediator)
        {
            _Mediator = mediator;
        }
        [Authorize(Roles = "Teacher")]
        [Route("/TeacherSubjects")]
        //Get All Subjects For Teacher
        public IActionResult Index(string TeacherId)
        {
            var query = new GetAllSubjectsForTeacherQuery { TeacherId = TeacherId };
            var response = _Mediator.Send(query);
            if (response.Result.Succeeded)
            {
                return View(response.Result.Data);
            }
            return View();
        }
        [Authorize(Roles = "Teacher")]
        public IActionResult AddSubject()
        {
            TempData["TeacherId"] = "123";
            return View(new AddSubjectCommand());
        }
        [Authorize(Roles = "Teacher")]
        [HttpPost]
        public IActionResult AddSubject(AddSubjectCommand subject)
        {
            subject.TeacherId = TempData["TeacherId"].ToString();
            var response = _Mediator.Send(subject);
            if (response.Result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View(subject);
        }
        [Authorize(Roles = "Teacher")]
        public IActionResult Exams(int SubjectId, string TeacherId)
        {
            var response = _Mediator.Send(new GetAllExamsDetailsForEachSubjectQuery { SubjectId = SubjectId });
            TempData["TeacherId"] = TeacherId;
            TempData["SubjectId"] = SubjectId;
            return View(response.Result.Data);
        }

    }
}
