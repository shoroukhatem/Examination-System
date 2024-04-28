using ExaminationSystem.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExaminationSystem
{
    public class Subject : BaseEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; } = Guid.NewGuid().ToString();
        public ApplicationUser Teacher { get; set; }
        [ForeignKey("Teacher")]
        public string TeacherId { get; set; }
        public List<Exam> Exams { get; set; } = new List<Exam>();

    }
}
