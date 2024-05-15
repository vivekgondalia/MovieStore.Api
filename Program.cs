
using MovieStore.Api.Entities;

List<Movie> movies = new()
{
    new Movie()
    {
        Id=1,
        Name="The Dark Knight",
        Genre="Action",
        ReleaseDate= new DateTime(2008, 01, 01),
        ImageUri = "https://placehold.co/100"
    },
    new Movie()
    {
        Id=2,
        Name="12 Angry Men",
        Genre="Drama",
        ReleaseDate= new DateTime(1960, 01, 01),
        ImageUri = "https://placehold.co/100"
    }
};

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/movies", () => movies);

app.MapGet("/movies/{id}", (int id) => movies.Find(movie => movie.Id == id));

app.Run();
