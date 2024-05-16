using MovieStore.Api.Entities;
using MovieStore.Api.Repositories;

namespace MovieStore.Api.Endpoints;

//this class is meant for extension methods and all extension methodsa shoul dbe static. Therfore, the class is going be a static class
public static class MoviesEndpoints
{
    const string GetMovieEndpointName = "GetMovie";



    public static RouteGroupBuilder MapMoviesEndpoints(this IEndpointRouteBuilder routes)
    {
        InMemMoviesRepository repository = new();

        var group = routes.MapGroup("/movies")
                .WithParameterValidation();

        group.MapGet("", () => repository.GetAll());

        group.MapGet("/{id}", (int id) =>
        {
            Movie? movie = repository.GetById(id);
            return movie is not null ? Results.Ok(movie) : Results.NotFound();
        })
        .WithName(GetMovieEndpointName);

        group.MapPost("", (Movie newMovie) =>
        {
            repository.Create(newMovie);
            //location header in the RESPONSE
            return Results.CreatedAtRoute(GetMovieEndpointName, new { id = newMovie.Id }, newMovie);
        });

        group.MapPut("/{id}", (int id, Movie updatedMovie) =>
        {
            Movie? existingMovie = repository.GetById(id);

            if (existingMovie is null)
                return Results.NotFound();

            existingMovie.Name = updatedMovie.Name;
            existingMovie.Genre = updatedMovie.Genre;
            existingMovie.ReleaseDate = updatedMovie.ReleaseDate;
            existingMovie.ImageUri = updatedMovie.ImageUri;

            repository.Update(existingMovie);
            return Results.NoContent();
        });

        group.MapDelete("/{id}", (int id) =>
        {
            Movie? movie = repository.GetById(id);

            if (movie is null)
                return Results.NotFound();

            repository.Delete(id);
            return Results.NoContent();
        });

        return group;
    }
}