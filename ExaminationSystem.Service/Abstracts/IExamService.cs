namespace ExaminationSystem.Service.Abstracts
{
    public interface IExamService
    {
        public Task<string> AddAsync(Exam exam);
        public Task<Exam> GetExamByIdAsync(int ExamId);
        public Task<IReadOnlyList<Exam>> GetAllExamsAsync();
        public Task<IReadOnlyList<Exam>> GetAllExamsDetailsForEachSubjectAsync(int subjectId);
    }
}
