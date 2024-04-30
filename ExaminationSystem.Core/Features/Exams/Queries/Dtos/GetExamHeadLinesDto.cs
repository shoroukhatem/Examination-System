namespace ExaminationSystem.Core.Features.Exams.Queries.Dtos
{
    public class GetExamHeadLinesDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double Duration { get; set; }
        public int FullMark { get; set; }
        public int SubjectId { get; set; }
        public string TeacherId { get; set; }
    }
}
