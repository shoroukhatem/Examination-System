using ExaminationSystem.Core.Bases;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ExaminationSystem.Core.Features.Exams.Commands.Models
{
    public class AddExamCommand : IRequest<Response<string>>
    {
        [Required]
        public string Name { get; set; }
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
        // public List<Question> Questions { get; set; } = new List<Question>();
        public int SubjectId { get; set; }
        /* public ApplicationUser Teacher { get; set; }
         [ForeignKey("Teacher")]*/
        public string TeacherId { get; set; }
    }
}
