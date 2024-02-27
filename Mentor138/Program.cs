using Mentor138.Abstractions.IRepositories;
using Mentor138.Abstractions.IRepositories.IEntitiesRepositories;
using Mentor138.Abstractions.IUnitOfWorks;
using Mentor138.Abstractions.Services;
using Mentor138.Contexts;
using Mentor138.Extentions;
using Mentor138.Implementations.Repositories;
using Mentor138.Implementations.Repositories.EntityRepositories;
using Mentor138.Implementations.Service;
using Mentor138.Implementations.UnitOfWorks;
using Mentor138.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var config = builder.Configuration.GetConnectionString("AppDbContext");
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(config));
builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Services.AddScoped<IStudentService,StudentService>();
builder.Services.AddScoped<ISchoolService, SchoolService>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ISchoolRepository, SchoolRepository>();
builder.Services.AddScoped(typeof(IGenericRepositories<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.ConfigureExtentionHandling();

app.UseAuthorization();

app.MapControllers();

app.Run();
