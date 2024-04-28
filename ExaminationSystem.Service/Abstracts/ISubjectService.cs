namespace ExaminationSystem.Service.Abstracts
{
    public interface ISubjectService
    {
        public Task<string> AddAsync(Subject subject);
        public Task<IReadOnlyList<Subject>> GetAllSubjectsAsync();
        public Task<IReadOnlyList<Subject>> GetAllSubjectsForTeacherAsync(string TeacherId);
    }
}
