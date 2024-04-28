using System.ComponentModel.DataAnnotations.Schema;

namespace ExaminationSystem.Domain.Entities
{
    public class SubjectStudent : BaseEntity<KeyValuePair<int, string>>
    {
        public Subject Subject { get; set; }
        [ForeignKey("Subject")]
        public int SubjectId { get; set; }
        public ApplicationUser Student { get; set; }
        [ForeignKey("Student")]
        public string StudentId { get; set; }
    }

}
