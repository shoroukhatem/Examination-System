namespace ExaminationSystem.Infrastructure.Repository.Interfaces
{
    public interface ISubjectRepository : IGenericRepository<Subject, int>
    {
        Task<IReadOnlyList<Subject>> GetAllSubjectsByTeacherAsync(string TeacherId);
    }
}
