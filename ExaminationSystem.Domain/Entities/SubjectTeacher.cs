using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Domain.Entities
{
    public class SubjectTeacher
    {
        public Subject Subject { get; set; }
        [ForeignKey("Subject")]
        public int SubjectId { get; set; }
        public ApplicationUser Teacher { get; set; }
        [ForeignKey("Student")]
        public string TeacherId { get; set; }
    }
}
