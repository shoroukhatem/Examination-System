namespace ExaminationSystem.Infrastructure.Specification.Answers
{
    public class AnswersWithSpecification : BaseSpecification<Answer>
    {
        #region Constructors
        public AnswersWithSpecification(AnswerSpecification specs)
                    : base(answer => !specs.QuestionId.HasValue || answer.QuestionId == specs.QuestionId.Value)
        {

        }
        #endregion
    }
}
