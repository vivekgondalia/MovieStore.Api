
using MovieStore.Api.Entities;

namespace MovieStore.Api.Repositories;

public interface IMoviesRepository
{
    Task CreateAsync(Movie newMovie);
    Task DeleteAsync(int id);
    Task<Movie?> GetByIdAsync(int id);
    Task<IEnumerable<Movie>> GetAllAsync();
    Task UpdateAsync(Movie updatedMovie);
}
