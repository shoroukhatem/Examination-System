using ExaminationSystem.Infrastructure.Repository.Interfaces;
using ExaminationSystem.Service.Abstracts;

namespace ExaminationSystem.Service.Implementation
{
    public class SubjectService : ISubjectService
    {
        #region Fields
        private readonly ISubjectRepository _Repository;
        private readonly IUnitOfWork _UnitOfWork;

        #endregion
        #region Constructors
        public SubjectService(ISubjectRepository repository, IUnitOfWork unitOfWork)
        {
            _Repository = repository;
            _UnitOfWork = unitOfWork;
        }
        #endregion
        #region Functions
        public async Task<string> AddAsync(Subject subject)
        {

            await _Repository.AddAsync(subject);
            var rowsAffected = await _UnitOfWork.CompelteAsync();
            return "Success";

        }

        public async Task<IReadOnlyList<Subject>> GetAllSubjectsAsync()
        {
            return await _Repository.GetAllAsync();
        }

        public Task<IReadOnlyList<Subject>> GetAllSubjectsForTeacherAsync(string TeacherId)
        {
            return _Repository.GetAllSubjectsByTeacherAsync(TeacherId);
        }
        #endregion
    }
}
