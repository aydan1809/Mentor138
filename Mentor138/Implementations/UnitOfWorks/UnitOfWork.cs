using Mentor138.Abstractions.IRepositories;
using Mentor138.Abstractions.IUnitOfWorks;
using Mentor138.Contexts;
using Mentor138.Entities.Comman;
using Mentor138.Implementations.Repositories;

namespace Mentor138.Implementations.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private Dictionary<Type, object> repostiories;
        public UnitOfWork( AppDbContext context)
        {
            _context = context;
             repostiories = new Dictionary<Type,object>();
           

        }
        public void Dispose()
        { 
            _context.Dispose();
        }

        public IGenericRepositories<TEntity> GetRespository<TEntity>() where TEntity : BaseEntity
        {
            if (repostiories.ContainsKey(typeof(TEntity)))
            {

                return (IGenericRepositories<TEntity>)repostiories[typeof(TEntity)];
            } 

            GenericRepository<TEntity> genericRepositories = new GenericRepository<TEntity>(_context);
            repostiories.Add(typeof(TEntity), genericRepositories); 
            return genericRepositories;
             
        }

        public async Task<int> SaveAsync()
        {
          return await _context.SaveChangesAsync();
        }
    }
}
