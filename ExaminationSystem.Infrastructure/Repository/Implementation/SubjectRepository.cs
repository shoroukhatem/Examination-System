using ExaminationSystem.Infrastructure.Context;
using ExaminationSystem.Infrastructure.Repository.Interfaces;

namespace ExaminationSystem.Infrastructure.Repository.Implementation
{
    public class SubjectRepository : GenericRepository<Subject, int>, ISubjectRepository

    {
        #region Fields

        private readonly ExamSystemDbContext _Context;
        #endregion
        #region Constructor
        public SubjectRepository(ExamSystemDbContext context) : base(context)
        {
            _Context = context;
        }
        #endregion
        #region Functions
        public async Task<IReadOnlyList<Subject>> GetAllSubjectsByTeacherAsync(string TeacherId)
        {
            return _Context.Set<Subject>().Where(sub => sub.TeacherId == TeacherId).ToList().AsReadOnly();
        }
        #endregion
    }
}
