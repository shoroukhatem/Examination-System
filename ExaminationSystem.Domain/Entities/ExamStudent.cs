using System.ComponentModel.DataAnnotations.Schema;

namespace ExaminationSystem.Domain.Entities
{
    public class ExamStudent : BaseEntity<KeyValuePair<int, string>>
    {
        public Exam Exam { get; set; }
        [ForeignKey("Exam")]
        public int ExamId { get; set; }
        public ApplicationUser Student { get; set; }
        [ForeignKey("Student")]
        public string StudentId { get; set; }
    }
}
