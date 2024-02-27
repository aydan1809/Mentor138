using Mentor138.Abstractions.IRepositories;
using Mentor138.Entities.Comman;
using System.Security.Cryptography.X509Certificates;

namespace Mentor138.Abstractions.IUnitOfWorks
{
    public interface IUnitOfWork :IDisposable
    {
        public Task<int> SaveAsync();
        public IGenericRepositories<TEntity> GetRespository <TEntity>() where TEntity : BaseEntity;

    }
}
;