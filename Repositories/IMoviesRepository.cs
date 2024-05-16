
using MovieStore.Api.Entities;

namespace MovieStore.Api.Repositories;

public interface IMoviesRepository
{
    void Create(Movie newMovie);
    void Delete(int id);
    Movie? GetById(int id);
    IEnumerable<Movie> GetAll();
    void Update(Movie updatedMovie);
}
