
using MovieStore.Api.Endpoints;
using MovieStore.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IMoviesRepository, InMemMoviesRepository>();

var app = builder.Build();

app.MapMoviesEndpoints();

app.Run();
