using ExaminationSystem.Domain.Entities;
using ExaminationSystem.Infrastructure.Specification;

namespace ExaminationSystem.Infrastructure.Repository.Interfaces
{
    public interface IGenericRepository<TEntity, Tkey> where TEntity : BaseEntity<Tkey>
    {
        Task<TEntity> GetByIdAsync(Tkey? id);
        Task<IReadOnlyList<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdWithSpecificationAsync(ISpecification<TEntity> specs);
        Task<IReadOnlyList<TEntity>> GetAllWithSpecificationAsync(ISpecification<TEntity> specs);
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
