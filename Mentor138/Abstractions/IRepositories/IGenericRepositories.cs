using Mentor138.Entities;
using Mentor138.Entities.Comman;
using Microsoft.EntityFrameworkCore;

namespace Mentor138.Abstractions.IRepositories
{
    public interface IGenericRepositories<T> where T : BaseEntity
    {
        public IQueryable<T> GetAll();
        public Task<bool> Add(T entity);
        public bool Update(T entity);
        public bool Delete(T entity);
        public Task<bool> DeleteById(int id);
        public Task<T> GetById(int id);
        DbSet<T> Table { get; }
    }
}
