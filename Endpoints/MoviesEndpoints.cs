using MovieStore.Api.Entities;

namespace MovieStore.Api.Endpoints;

//this class is meant for extension methods and all extension methodsa shoul dbe static. Therfore, the class is going be a static class
public static class MoviesEndpoints
{
    const string GetMovieEndpointName = "GetMovie";

    

    public static RouteGroupBuilder MapMoviesEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/movies")
                .WithParameterValidation();

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

        return group;
    }
}