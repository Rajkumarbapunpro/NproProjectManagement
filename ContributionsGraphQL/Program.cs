using GraphQL.Types;
using GraphQL;
using ContributionsGraphQL.Schemas;
using ContributionsGraphQL.Dapper;
using ContributionsGraphQL.Repository.Interface;
using ContributionsGraphQL.Mutation;
using ContributionsGraphQL.Models;
using ContributionsGraphQL.Query;
using ContributionsGraphQL.Repository;
using ContributionsGraphQL.Type;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddTransient<IContributionRepository, ContributionRepository>();
builder.Services.AddSingleton<IDocumentExecuter, DocumentExecuter>();

builder.Services.AddSingleton<ContributionMutation>();
builder.Services.AddSingleton<Contributions>();
builder.Services.AddSingleton<ContributionQuery>();
builder.Services.AddSingleton<ContributionType>();
builder.Services.AddSingleton<ContributionsInputType>();
builder.Services.AddSingleton<ContributionsInfoType>();
builder.Services.AddControllers().AddNewtonsoftJson();
var sp = builder.Services.BuildServiceProvider();
builder.Services.AddSingleton<ISchema>(new ContributionSchema(new FuncDependencyResolver(type => sp.GetService(type))));



builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
