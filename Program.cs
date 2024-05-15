
using MovieStore.Api.Entities;

const string GetMovieEndpointName = "GetMovie";

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

var group = app.MapGroup("/movies");

group.MapGet("", () => movies);

group.MapGet("/{id}", (int id) =>
{

    Movie? movie = movies.Find(movie => movie.Id == id);

    if (movie is null)
        return Results.NotFound();

    return Results.Ok(movie);
})
.WithName(GetMovieEndpointName);

group.MapPost("", (Movie newMovie) =>
{
    newMovie.Id = movies.Max(movie => movie.Id) + 1;
    movies.Add(newMovie);

    //location header in the RESPONSE
    return Results.CreatedAtRoute(GetMovieEndpointName, new { id = newMovie.Id }, newMovie);
});

group.MapPut("/{id}", (int id, Movie updatedMovie) =>
{
    Movie? existingMovie = movies.Find(movie => movie.Id == id);

    if (existingMovie is null)
        return Results.NotFound();

    existingMovie.Name = updatedMovie.Name;
    existingMovie.Genre = updatedMovie.Genre;
    existingMovie.ReleaseDate = updatedMovie.ReleaseDate;
    existingMovie.ImageUri = updatedMovie.ImageUri;

    return Results.NoContent();
});

group.MapDelete("/{id}", (int id) =>
{
    Movie? movie = movies.Find(movie => movie.Id == id);

    if (movie is null)
        return Results.NotFound();

    return Results.NoContent();
});

app.Run();
