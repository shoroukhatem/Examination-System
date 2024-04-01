using ExaminationSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    public class Exam
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime StartTime {  get; set; }
        [Required]
        public DateTime EndTime {  get; set; }
        [Required]
        public double Duration { get; set; }
        [Required]
        public int NumberOfQuestions { get; set; }
        [Required]
        public int FullMark { get; set; }
       public List<Question>Questions { get; set; } = new List<Question>();
        public int SubjectId { get; set; }
        public ApplicationUser Teacher { get; set; }
        [ForeignKey("Teacher")]
        public string TeacherId { get;set; }

      
    }
}
