using ExaminationSystem.Infrastructure.Repository.Interfaces;
using ExaminationSystem.Infrastructure.Specification.Subjects;
using ExaminationSystem.Service.Abstracts;

namespace ExaminationSystem.Service.Implementation
{
    public class SubjectService : ISubjectService
    {
        #region Fields

        private readonly IUnitOfWork _UnitOfWork;

        #endregion
        #region Constructors
        public SubjectService(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }
        #endregion
        #region Functions
        public async Task<string> AddAsync(Subject subject)
        {

            await _UnitOfWork.Repository<Subject, int>().AddAsync(subject);
            var rowsAffected = await _UnitOfWork.CompelteAsync();
            return "Success";

        }

        public async Task<IReadOnlyList<Subject>> GetAllSubjectsAsync()
        {
            return await _UnitOfWork.Repository<Subject, int>().GetAllAsync();
        }

        public Task<IReadOnlyList<Subject>> GetAllSubjectsForTeacherAsync(string TeacherId)
        {
            SubjectSpecification subjectSpecification = new SubjectSpecification() { TeacherId = TeacherId };
            var specs = new SubjectWithSpecification(subjectSpecification);
            return _UnitOfWork.Repository<Subject, int>().GetAllWithSpecificationAsync(specs);
        }
        #endregion
    }
}
