
using System.Security.Claims;
using MovieStore.Api.Data;
using MovieStore.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRepositories(builder.Configuration);

builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddAuthorization();

var app = builder.Build();

await app.Services.InitializeDbAsync();

app.MapMoviesEndpoints().RequireAuthorization(policy =>
{
    policy.RequireRole("admin");
});

//Customers and their movies
Dictionary<string, List<string>> moviesMap = new()
{
    {"Vivek Gondalia", new List<string>(){"The Dark Knight"}},
    {"Customer2", new List<string>(){"The Dark Knight Rises", "12 Angry Men"}},
};

//customer subscription model
Dictionary<string, List<string>> subcriptionMap = new()
{
    {"silver", new List<string>(){"Batman Begins"}},
    {"gold", new List<string>(){"Batman Begins", "The Dark Knight","The Dark Knight Rises", "12 Angry Men"}},
};

// customer - get individual user movie list 
app.MapGet("/mymovies", (ClaimsPrincipal user) =>
{
    //find user subscription and return specific list of movies
    var hasClaim = user.HasClaim(claim => claim.Type == "subscription");
    if (hasClaim)
    {
        var subs = user.FindFirstValue("subscription") ?? throw new Exception("Claim has no value!");
        return Results.Ok(subcriptionMap[subs]);
    }

    ArgumentNullException.ThrowIfNull(user.Identity?.Name);
    var username = user.Identity.Name;

    if (!moviesMap.ContainsKey(username))
    {
        return Results.Empty;
    }

    return Results.Ok(moviesMap[username]);
}).RequireAuthorization(policy =>
{
    policy.RequireRole("customer");
});

app.Run();
