using AutoMapper;
using ExaminationSystem.Core.Bases;
using ExaminationSystem.Core.Features.Subject.Queries.Dtos;
using ExaminationSystem.Core.Features.Subject.Queries.Models;
using ExaminationSystem.Service.Abstracts;
using MediatR;

namespace ExaminationSystem.Core.Features.Subject.Queries.Handler
{
    public class SubjectQueryHandler : ResponseHandler,
                                       IRequestHandler<GetAllSubjectsForTeacherQuery, Response<IReadOnlyList<GetSubjectDto>>>
    {
        #region Fields
        private readonly IMapper _Mapper;
        private readonly ISubjectService _SubjectService;

        #endregion
        #region Constructor
        public SubjectQueryHandler(IMapper mapper, ISubjectService subjectService)
        {
            _Mapper = mapper;
            _SubjectService = subjectService;
        }
        #endregion
        #region Handlers
        //Get All Subjects For Teacher
        public async Task<Response<IReadOnlyList<GetSubjectDto>>> Handle(GetAllSubjectsForTeacherQuery request, CancellationToken cancellationToken)
        {

            var SubjectsList = await _SubjectService.GetAllSubjectsForTeacherAsync(request.TeacherId);
            var MappedSubjectsList = _Mapper.Map<IReadOnlyList<GetSubjectDto>>(SubjectsList);
            return Success(MappedSubjectsList);
        }
        #endregion
    }
}
