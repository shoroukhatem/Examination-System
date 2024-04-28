using ExaminationSystem.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExaminationSystem
{
    public class Exam : BaseEntity<int>
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        [Required]
        public double Duration { get; set; }
        [Required]
        public int NumberOfQuestions { get; set; }
        [Required]
        public int FullMark { get; set; }
        public List<Question> Questions { get; set; } = new List<Question>();
        public int SubjectId { get; set; }
        public ApplicationUser Teacher { get; set; }
        [ForeignKey("Teacher")]
        public string TeacherId { get; set; }


    }
}
