using Microsoft.IdentityModel.Tokens;

namespace ExaminationSystem.Infrastructure.Specification.Subjects
{
    public class SubjectWithSpecification : BaseSpecification<Subject>
    {
        #region Constructors
        public SubjectWithSpecification(SubjectSpecification specs)
                    : base(exam => !specs.TeacherId.IsNullOrEmpty() || exam.TeacherId == specs.TeacherId)
        {

        }
        public SubjectWithSpecification(int? id)
                    : base(exam => exam.Id == id)
        {

        }
        #endregion
    }
}
