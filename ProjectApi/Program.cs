using ProjectApi.Dapper;
using ProjectApi.Interfaces;
using ProjectApi.Model;
using ProjectApi.Repository;
using ProjectApi.Repository.Interface;
using ProjectApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<DapperContext>();
builder.Services.AddTransient<IProjectRepository, ProjectRepository>();
builder.Services.AddSingleton<IProjectService, ProjectService>();
builder.Services.AddSingleton<ProjectDetail>();


// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
