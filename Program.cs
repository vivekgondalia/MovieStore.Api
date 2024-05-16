
using MovieStore.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapMoviesEndpoints();

app.Run();
