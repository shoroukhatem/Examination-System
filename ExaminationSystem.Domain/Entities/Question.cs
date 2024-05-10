using ExaminationSystem.Domain.Entities;

namespace ExaminationSystem
{
    public/* abstract */class Question : BaseEntity<int>
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public double Mark { get; set; }
        public int ExamId { get; set; }
        public string QuestionType { get; set; }
        public Answer? Correct { get; set; }
        public int? TrueAnswer { get; set; }

    }

}
