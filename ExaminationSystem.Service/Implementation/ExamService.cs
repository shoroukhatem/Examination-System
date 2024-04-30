using ExaminationSystem.Infrastructure.Repository.Interfaces;
using ExaminationSystem.Infrastructure.Specification.Exams;
using ExaminationSystem.Service.Abstracts;

namespace ExaminationSystem.Service.Implementation
{
    public class ExamService : IExamService
    {
        #region Fields
        private readonly IUnitOfWork _UnitOfWork;
        // private readonly ILogger _Logger;

        #endregion
        #region Constructors
        public ExamService(IUnitOfWork unitOfWork/*, ILogger logger*/)
        {

            _UnitOfWork = unitOfWork;
            //_Logger = logger;
        }
        #endregion
        #region Functions
        public async Task<string> AddAsync(Exam exam)
        {
            try
            {
                await _UnitOfWork.Repository<Exam, int>().AddAsync(exam);
                await _UnitOfWork.CompelteAsync();
                return "Success";

            }
            catch (Exception ex)
            {
                // _Logger.LogError(ex.Message);
                return "Failed";
            }
        }

        public async Task<IReadOnlyList<Exam>> GetAllExamsAsync()
        {
            return await _UnitOfWork.Repository<Exam, int>().GetAllAsync();
        }

        public async Task<IReadOnlyList<Exam>> GetAllExamsDetailsForEachSubjectAsync(int subjectId)
        {

            var specs = new ExamsWithSpecification(new ExamSpecification { SubjectId = subjectId });
            return await _UnitOfWork.Repository<Exam, int>().GetAllWithSpecificationAsync(specs);
        }

        public Task<Exam> GetExamByIdAsync(int ExamId)
        {
            return _UnitOfWork.Repository<Exam, int>().GetByIdAsync(ExamId);
        }
        #endregion
    }
}
