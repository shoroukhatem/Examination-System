using ExaminationSystem.Domain.Entities;
using ExaminationSystem.Infrastructure.Context;
using ExaminationSystem.Infrastructure.Repository.Implementation;
using ExaminationSystem.Infrastructure.Repository.Interfaces;
using System.Collections;

namespace Store.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ExamSystemDbContext context;
        private Hashtable _repositories;

        public UnitOfWork(ExamSystemDbContext context)
        {
            this.context = context;
        }
        public async Task<int> CompelteAsync() => await context.SaveChangesAsync();

        public IGenericRepository<TEntity, Tkey> Repository<TEntity, Tkey>() where TEntity : BaseEntity<Tkey>
        {
            if (_repositories == null) _repositories = new Hashtable();
            var entityKey = typeof(TEntity).Name;
            if (!_repositories.ContainsKey(entityKey))
            {
                var repositoryType = typeof(GenericRepository<,>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity), typeof(Tkey)), context);
                _repositories.Add(entityKey, repositoryInstance);
            }
            return (IGenericRepository<TEntity, Tkey>)_repositories[entityKey];
        }
    }
}
