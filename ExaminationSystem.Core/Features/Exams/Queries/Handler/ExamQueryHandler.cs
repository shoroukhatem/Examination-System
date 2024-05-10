using AutoMapper;
using ExaminationSystem.Core.Bases;
using ExaminationSystem.Core.Features.Exams.Queries.Dtos;
using ExaminationSystem.Core.Features.Exams.Queries.Models;
using ExaminationSystem.Service.Abstracts;
using MediatR;

namespace ExaminationSystem.Core.Features.Exams.Queries.Handler
{
    public class ExamQueryHandler : ResponseHandler
                                    , IRequestHandler<GetAllExamsDetailsForEachSubjectQuery, Response<IReadOnlyList<GetExamHeadLinesDto>>>
                                    , IRequestHandler<GetExamQuery, Response<GetExamDto>>
    {
        #region Fields
        private readonly IMapper _Mapper;
        private readonly IExamService _ExamService;


        #endregion
        #region Constructor
        public ExamQueryHandler(IMapper mapper, IExamService examService)
        {
            _Mapper = mapper;
            _ExamService = examService;
        }
        #endregion
        #region Handlers
        //List All Exams Details For each Subject
        public async Task<Response<IReadOnlyList<GetExamHeadLinesDto>>> Handle(GetAllExamsDetailsForEachSubjectQuery request, CancellationToken cancellationToken)
        {
            var ExamList = await _ExamService.GetAllExamsDetailsForEachSubjectAsync(request.SubjectId);
            var MappedExamList = _Mapper.Map<IReadOnlyList<GetExamHeadLinesDto>>(ExamList);
            return Success(MappedExamList);
        }
        //Get Exam By Id
        public async Task<Response<GetExamDto>> Handle(GetExamQuery request, CancellationToken cancellationToken)
        {
            var exam = await _ExamService.GetExamByIdAsync(request.ExamId);
            if (exam == null)
            {
                return BadRequest<GetExamDto>("Exam Is Not Exist");
            }
            var ExamDto = _Mapper.Map<GetExamDto>(exam);
            return Success(ExamDto);
        }

        #endregion
    }
}
