using System.ComponentModel.DataAnnotations.Schema;

namespace ExaminationSystem.Domain.Entities
{
    public class SubjectTeacher : BaseEntity<KeyValuePair<int, string>>
    {
        public Subject Subject { get; set; }
        [ForeignKey("Subject")]
        public int SubjectId { get; set; }
        public ApplicationUser Teacher { get; set; }
        [ForeignKey("Student")]
        public string TeacherId { get; set; }
    }
}
