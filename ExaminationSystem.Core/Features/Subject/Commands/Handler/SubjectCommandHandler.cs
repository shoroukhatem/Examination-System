using AutoMapper;
using ExaminationSystem.Core.Bases;
using ExaminationSystem.Core.Features.Subject.Commands.Models;
using ExaminationSystem.Service.Abstracts;
using MediatR;
namespace ExaminationSystem.Core.Features.Subject.Commands.Handler
{
    public class SubjectCommandHandler : ResponseHandler, IRequestHandler<AddSubjectCommand, Response<string>>
    {

        #region Fields
        private readonly IMapper _Mapper;
        private readonly ISubjectService _SubjectService;

        #endregion
        #region Constructor
        public SubjectCommandHandler(IMapper mapper, ISubjectService subjectService)
        {
            _Mapper = mapper;
            _SubjectService = subjectService;
        }
        #endregion
        #region Handle Functions
        public async Task<Response<string>> Handle(AddSubjectCommand request, CancellationToken cancellationToken)
        {
            var subject = _Mapper.Map<ExaminationSystem.Subject>(request);
            var result = await _SubjectService.AddAsync(subject);
            if (result == "Success")
            {
                return Created("");
            }
            return BadRequest<string>(result);
        }
        #endregion
    }
}
