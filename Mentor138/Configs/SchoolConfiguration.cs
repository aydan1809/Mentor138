using Mentor138.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mentor138.Configs
{
    public class SchoolConfiguration : IEntityTypeConfiguration<School>
    {

        public void Configure(EntityTypeBuilder<School> builder)
        {
            builder.Property(x => x.SchoolName).IsRequired().HasMaxLength(20);
            
        }
    }
}
