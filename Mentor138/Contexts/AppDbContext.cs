using Mentor138.Configs;
using Mentor138.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mentor138.Contexts;

public class AppDbContext:DbContext
{
    public DbSet<School> Schools {  get; set; }  
    public DbSet<Student> Students { get; set; }
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SchoolConfiguration).Assembly);
       
    }
} 
