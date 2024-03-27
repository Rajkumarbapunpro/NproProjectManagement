using ContributionsApi.BusinessService;
using ContributionsApi.BusinessService.Interface;
using ContributionsApi.Dapper;
using ContributionsApi.Models;
using ContributionsApi.Repository;
using ContributionsApi.Repository.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<DapperContext>();
builder.Services.AddTransient<IContributionRepository, ContributionRepository>();
builder.Services.AddSingleton<IContributionsService, ContributionsService>();
builder.Services.AddSingleton<Contributions>();

builder.Services.AddControllers();

var app = builder.Build();


// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
