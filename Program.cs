
using Microsoft.EntityFrameworkCore;
using MovieStore.Api.Data;
using MovieStore.Api.Endpoints;
using MovieStore.Api.Repositories;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IMoviesRepository, InMemMoviesRepository>();

string? connString = builder.Configuration.GetConnectionString("MovieStoreContext");
builder.Services.AddDbContextPool<MovieStoreContext>(options => options.UseMySql(connString, ServerVersion.AutoDetect(connString)));

var app = builder.Build();

app.Services.InitializeDb();

app.MapMoviesEndpoints();

app.Run();
