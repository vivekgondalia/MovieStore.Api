using System.ComponentModel.DataAnnotations;

namespace MovieStore.Api.Dtos;

//contract between client and server

public record MovieDto(
    int Id,
    string Name,
    string Genre,
    decimal NumberOfCopies,
    DateTime ReleaseDate,
    string ImageUri
);

public record CreateMovieDto(
    [Required][StringLength(50)] string Name,
    [Required][StringLength(20)] string Genre,
    [Range(1, 3)] decimal NumberOfCopies,
    DateTime ReleaseDate,
    [Url][StringLength(100)] string ImageUri
);

public record UpdateMovieDto(
    [Required][StringLength(50)] string Name,
    [Required][StringLength(20)] string Genre,
    [Range(1, 3)] decimal NumberOfCopies,
    DateTime ReleaseDate,
    [Url][StringLength(100)] string ImageUri
);

