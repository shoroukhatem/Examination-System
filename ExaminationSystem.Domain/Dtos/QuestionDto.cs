namespace ExaminationSystem.Domain.Dtos
{
    public class QuestionDto
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public double Mark { get; set; }
        public int ExamId { get; set; }
        public string QuestionType { get; set; }
        public Answer? Correct { get; set; }
        public int? TrueAnswer { get; set; }
        public List<Answer>? Answers { get; set; } = new List<Answer>();
    }
}
