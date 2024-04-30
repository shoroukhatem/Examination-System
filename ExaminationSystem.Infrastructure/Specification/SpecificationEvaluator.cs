using ExaminationSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ExaminationSystem.Infrastructure.Specification
{
    public class SpecificationEvaluator<TEntity, Tkey> where TEntity : BaseEntity<Tkey>
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> specs)
        {
            var query = inputQuery;
            if (specs.Criteria != null)
            {
                query = query.Where(specs.Criteria);
            }
            if (!specs.Includes.IsNullOrEmpty())
            {
                query = specs.Includes.Aggregate(query, (current, includeExpression) => current.Include(includeExpression));
            }
            return query;
        }
    }
}
