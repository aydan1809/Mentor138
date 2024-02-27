using Mentor138.Abstractions.IRepositories.IEntitiesRepositories;
using Mentor138.Contexts;
using Mentor138.Entities;

namespace Mentor138.Implementations.Repositories.EntityRepositories
{
    public class SchoolRepository : GenericRepository<School>, ISchoolRepository
    {
        public SchoolRepository(AppDbContext context) : base(context)
        {
        }
    }
}
