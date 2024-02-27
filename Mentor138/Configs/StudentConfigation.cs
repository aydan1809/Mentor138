using Mentor138.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mentor138.Configs
{
    public class StudentConfigation : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(x=>x.Name).IsRequired().HasMaxLength(20);
            builder.Property(x => x.SchoolId).IsRequired();
        }
    }
}
