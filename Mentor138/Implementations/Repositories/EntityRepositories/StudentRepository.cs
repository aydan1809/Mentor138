using Mentor138.Abstractions.IRepositories;
using Mentor138.Abstractions.IRepositories.IEntitiesRepositories;
using Mentor138.Contexts;
using Mentor138.Entities;

namespace Mentor138.Implementations.Repositories.EntityRepositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(AppDbContext context) : base(context)
        {
        }
    }
}
