namespace ExaminationSystem.Infrastructure.Specification.Exams
{
    public class ExamsWithSpecification : BaseSpecification<Exam>
    {
        #region Constructors
        public ExamsWithSpecification(ExamSpecification specs)
                    : base(exam => !specs.SubjectId.HasValue || exam.SubjectId == specs.SubjectId.Value)
        {

        }
        public ExamsWithSpecification(int? id)
                    : base(exam => exam.Id == id)
        {

        }
        #endregion
    }
}
