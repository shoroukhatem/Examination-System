using AutoMapper;
using ExaminationSystem.Core.Bases;
using ExaminationSystem.Core.Features.Exams.Commands.Models;
using ExaminationSystem.Service.Abstracts;
using MediatR;

namespace ExaminationSystem.Core.Features.Exams.Commands.Handler
{
    public class ExamCommandHandler : ResponseHandler, IRequestHandler<AddExamCommand, Response<string>>
    {

        #region Fields
        private readonly IMapper _Mapper;
        private readonly IExamService _ExamService;


        #endregion
        #region Constructor
        public ExamCommandHandler(IMapper mapper, IExamService examService)
        {
            _Mapper = mapper;
            _ExamService = examService;
        }
        #endregion
        #region Handle Functions
        public async Task<Response<string>> Handle(AddExamCommand request, CancellationToken cancellationToken)
        {
            var exam = _Mapper.Map<Exam>(request);
            var result = await _ExamService.AddAsync(exam);
            if (result == "Success")
            {
                return Created("");
            }
            return BadRequest<string>(result);
        }
        #endregion

    }
}
