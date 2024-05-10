namespace ExaminationSystem.Service.Abstracts
{
    public interface IQuestionService
    {
        public Task<int> AddAsync(Question question);
        public Task<Question> GetQuestionByIdAsync(int questionId);
        //public Task<IReadOnlyList<Exam>> GetAllQuestionAsync();
        public Task<int> UpdateAsync(Question question);
        public Task<IReadOnlyList<Question>> GetAllQuestionsForEachExamAsync(int examId);
    }
}
