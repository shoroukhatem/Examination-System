namespace ExaminationSystem.Service.Abstracts
{
    public interface IAnswerService
    {
        public Task<List<int>> AddListofAnswers(List<Answer> answers);
        public Task<IReadOnlyList<Answer>> GetListofAnswersForQuestionAsync(int questionId);
    }
}
