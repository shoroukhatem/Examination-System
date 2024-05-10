namespace ExaminationSystem.Core.Features.Questions.Queries.Dtos
{
    public class GetQuestionWithAnswersDto
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public double Mark { get; set; }
        public IReadOnlyList<Answer> Answers { get; set; }
        public int TrueAnswer { get; set; }
        public int ExamId { get; set; }
        public string QuestionType { get; set; }
    }
}
