using ExaminationSystem.Domain.Entities;
using ExaminationSystem.Infrastructure.Context;
using ExaminationSystem.Infrastructure.Repository.Interfaces;
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
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<TEntity>> GetAllAsync() => await _Context.Set<TEntity>().ToListAsync();

        public Task<TEntity> GetByIdAsync(Tkey? id)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
