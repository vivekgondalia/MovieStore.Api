using MovieStore.Api.Dtos;

namespace MovieStore.Api.Entities;

public static class EntityExtensions
{
    public static MovieDto AsDto(this Movie movie)
    {
        return new MovieDto(
            movie.Id,
            movie.Name,
            movie.Genre,
            movie.NumberOfCopies,
            movie.ReleaseDate,
            movie.ImageUri
        );
    }
}