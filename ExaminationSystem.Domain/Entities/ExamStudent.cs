using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Domain.Entities
{
    public class ExamStudent
    {
        public Exam Exam { get; set; }
        [ForeignKey("Exam")]
        public int ExamId {  get; set; }
        public ApplicationUser Student { get; set; }
        [ForeignKey("Student")]
        public string StudentId { get; set;}
    }
}
