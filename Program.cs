
using MovieStore.Api.Endpoints;
using MovieStore.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IMoviesRepository, InMemMoviesRepository>();

var connString = builder.Configuration.GetConnectionString("MovieStoreContext");

var app = builder.Build();

app.MapMoviesEndpoints();

app.Run();
