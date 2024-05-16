using MovieStore.Api.Dtos;
using MovieStore.Api.Entities;
using MovieStore.Api.Repositories;

namespace MovieStore.Api.Endpoints;

//this class is meant for extension methods and all extension methodsa shoul dbe static. Therfore, the class is going be a static class
public static class MoviesEndpoints
{
    const string GetMovieEndpointName = "GetMovie";

    public static RouteGroupBuilder MapMoviesEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/movies")
                .WithParameterValidation();

        group.MapGet("", (IMoviesRepository repository) =>
            repository.GetAll().Select(movie => movie.AsDto()));

        group.MapGet("/{id}", (IMoviesRepository repository, int id) =>
        {
            Movie? movie = repository.GetById(id);
            return movie is not null ? Results.Ok(movie.AsDto()) : Results.NotFound();
        })
        .WithName(GetMovieEndpointName);

        group.MapPost("", (IMoviesRepository repository, CreateMovieDto newMovieDto) =>
        {
            Movie newMovie = new()
            {
                Name = newMovieDto.Name,
                Genre = newMovieDto.Genre,
                NumberOfCopies = newMovieDto.NumberOfCopies,
                ReleaseDate = newMovieDto.ReleaseDate,
                ImageUri = newMovieDto.ImageUri
            };

            repository.Create(newMovie);
            //location header in the RESPONSE
            return Results.CreatedAtRoute(GetMovieEndpointName, new { id = newMovie.Id }, newMovie);
        });

        group.MapPut("/{id}", (IMoviesRepository repository, int id, UpdateMovieDto updatedMovieDto) =>
        {
            Movie? existingMovie = repository.GetById(id);

            if (existingMovie is null)
                return Results.NotFound();

            existingMovie.Name = updatedMovieDto.Name;
            existingMovie.Genre = updatedMovieDto.Genre;
            existingMovie.NumberOfCopies = updatedMovieDto.NumberOfCopies;
            existingMovie.ReleaseDate = updatedMovieDto.ReleaseDate;
            existingMovie.ImageUri = updatedMovieDto.ImageUri;

            repository.Update(existingMovie);
            return Results.NoContent();
        });

        group.MapDelete("/{id}", (IMoviesRepository repository, int id) =>
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