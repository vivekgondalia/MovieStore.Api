
using MovieStore.Api.Data;
using MovieStore.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRepositories(builder.Configuration);

builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddAuthorization();

var app = builder.Build();

await app.Services.InitializeDbAsync();

app.MapMoviesEndpoints().RequireAuthorization();

app.Run();
