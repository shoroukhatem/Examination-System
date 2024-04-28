using ExaminationSystem.Domain.Entities;

namespace ExaminationSystem.Infrastructure.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<TEntity, Tkey> Repository<TEntity, Tkey>() where TEntity : BaseEntity<Tkey>;

        Task<int> CompelteAsync();
    }
}
