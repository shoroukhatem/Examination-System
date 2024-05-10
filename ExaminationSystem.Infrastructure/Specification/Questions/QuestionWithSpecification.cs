namespace ExaminationSystem.Infrastructure.Specification.Questions
{
    public class QuestionWithSpecification : BaseSpecification<Question>
    {
        #region Constructors
        public QuestionWithSpecification(QuestionSpecification specs)
                    : base(question => !specs.examId.HasValue || question.ExamId == specs.examId.Value)
        {

        }
        public QuestionWithSpecification(int? id)
                    : base(exam => exam.Id == id)
        {

        }
        #endregion
    }
}
