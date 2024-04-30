namespace ExaminationSystem.Core.Features.Exams.Queries.Dtos
{
    public class GetExamDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double Duration { get; set; }
        public int NumberOfQuestions { get; set; }
        public int FullMark { get; set; }
        public List<Question> Questions { get; set; } = new List<Question>();
        ///public int SubjectId { get; set; }
        // public ApplicationUser Teacher { get; set; }
        // [ForeignKey("Teacher")]
        // public string TeacherId { get; set; }
    }
}
