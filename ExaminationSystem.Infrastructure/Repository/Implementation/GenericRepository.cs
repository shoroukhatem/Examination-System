using ExaminationSystem.Domain.Entities;
using ExaminationSystem.Infrastructure.Context;
using ExaminationSystem.Infrastructure.Repository.Interfaces;
using ExaminationSystem.Infrastructure.Specification;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSystem.Infrastructure.Repository.Implementation
{
    public class GenericRepository<TEntity, Tkey> : IGenericRepository<TEntity, Tkey> where TEntity : BaseEntity<Tkey>
    {
        #region Fields
        private readonly ExamSystemDbContext _Context;

        #endregion
        #region Constructor
        public GenericRepository(ExamSystemDbContext context)
        {
            _Context = context;
        }
        #endregion
        #region Functions
        public async Task AddAsync(TEntity entity) => await _Context.Set<TEntity>().AddAsync(entity);


        public void Delete(TEntity entity)
        {
            _Context.Set<TEntity>().Remove(entity);
        }

        public async Task<IReadOnlyList<TEntity>> GetAllAsync() => await _Context.Set<TEntity>().ToListAsync();

        public async Task<IReadOnlyList<TEntity>> GetAllWithSpecificationAsync(ISpecification<TEntity> specs)
        {
            return await ApplySpecification(specs).ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Tkey? id)
        {
            return await _Context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> GetByIdWithSpecificationAsync(ISpecification<TEntity> specs)
        {
            return await ApplySpecification(specs).FirstOrDefaultAsync();
        }

        public void Update(TEntity entity)
        {
            _Context.Set<TEntity>().Update(entity);
        }
        private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> specs)
        {
            return SpecificationEvaluator<TEntity, Tkey>.GetQuery(_Context.Set<TEntity>(), specs);
        }
        #endregion
    }
}
