using ExaminationSystem.Domain.Entities;

namespace ExaminationSystem
{
    public class Question : BaseEntity<int>
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public double Mark { get; set; }
        public Answer TrueAnswer { get; set; }
        // [ForeignKey("Exam")]
        public int ExamId { get; set; }
        public string QuestionType { get; set; }


    }

}
