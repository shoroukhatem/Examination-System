using System.Linq.Expressions;

namespace ExaminationSystem.Infrastructure.Specification
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        #region Properties
        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; }
        #endregion
        #region Constructor
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        #endregion
        #region Functions
        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
        #endregion
    }
}
