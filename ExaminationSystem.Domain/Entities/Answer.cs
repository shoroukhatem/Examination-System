using ExaminationSystem.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExaminationSystem
{
    public class Answer : BaseEntity<int>
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }
        public Question Question { get; set; }
        [ForeignKey("Question")]
        public int QuestionId { get; set; }

    }
}
