using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    public class Question
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public double Mark { get; set; }
        public Answer TrueAnswer { get; set; }
       // [ForeignKey("Exam")]
        public int ExamId {  get; set; }
        public string QuestionType {  get; set; }
   

    }

}
