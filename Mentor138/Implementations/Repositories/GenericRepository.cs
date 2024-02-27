using Mentor138.Abstractions.IRepositories;
using Mentor138.Contexts;
using Mentor138.Entities.Comman;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Mentor138.Implementations.Repositories
{
    public class GenericRepository<T> : IGenericRepositories<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        public GenericRepository(AppDbContext context)
        {
            _context = context; 
        }
        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> Add(T entity)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(entity);
            return entityEntry.State == EntityState.Added;
        }

        public  bool Delete(T entity)
        {
            EntityEntry<T> entityEntry = Table.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<bool> DeleteById(int id)
        {
           T data= await Table.FindAsync(id);
            return Delete(data);
        }

        public IQueryable<T> GetAll()
        {
           var query=Table.AsQueryable();
            return query;
        }

        public async Task<T> GetById(int id)
        {
           T data = await Table.FirstOrDefaultAsync(x=>x.Id==id);
            return data;
        }

        public bool Update(T entity)
        {
            EntityEntry<T> entityEntry = Table.Update(entity);
            return entityEntry.State == EntityState.Modified;
        }
    }
}
