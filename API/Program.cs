using bancodigital_api.Data;
using bancodigital_api.Data.Repositories;
using bancodigital_api.GraphQl;
using bancodigital_api.GraphQl.mutations;
using bancodigital_api.GraphQl.queries;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection"));
});


builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<ContaMutation>();

    builder.Services.AddScoped<IContaRepository, ContaRepository>();

var app = builder.Build();


var option = new RewriteOptions();
option.AddRedirect("^$", "graphql");
app.UseRewriter(option);

app.MapGraphQL();

app.Run();
