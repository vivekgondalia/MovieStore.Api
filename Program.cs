
using MovieStore.Api.Data;
using MovieStore.Api.Endpoints;
using MovieStore.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IMoviesRepository, InMemMoviesRepository>();

var connString = builder.Configuration.GetConnectionString("MovieStoreContext");
builder.Services.AddSqlServer<MovieStoreContext>(connString);

var app = builder.Build();

app.MapMoviesEndpoints();

app.Run();
