
using MovieStore.Api.Entities;

namespace MovieStore.Api.Repositories;

public class InMemMoviesRepository : IMoviesRepository
{
    private readonly List<Movie> movies = new()
    {
        new Movie()
        {
            Id=1,
            Name="The Dark Knight",
            Genre="Action",
            NumberOfCopies=3,
            ReleaseDate= new DateTime(2008, 01, 01),
            ImageUri = "https://placehold.co/100"
        },
        new Movie()
        {
            Id=2,
            Name="12 Angry Men",
            Genre="Drama",
            NumberOfCopies=1,
            ReleaseDate= new DateTime(1960, 01, 01),
            ImageUri = "https://placehold.co/100"
        }
    };

    public async Task<IEnumerable<Movie>> GetAllAsync()
    {
        //use FromResult() no need to wait as movies are in memory here
        return await Task.FromResult(movies);
    }

    public async Task<Movie?> GetByIdAsync(int id)
    {
        return await Task.FromResult(movies.Find(movie => movie.Id == id));
    }

    public async Task CreateAsync(Movie newMovie)
    {
        newMovie.Id = movies.Max(movie => movie.Id) + 1;
        movies.Add(newMovie);

        await Task.CompletedTask;
    }

    public async Task UpdateAsync(Movie updatedMovie)
    {
        var index = movies.FindIndex(movie => movie.Id == updatedMovie.Id);
        movies[index] = updatedMovie;

        await Task.CompletedTask;
    }

    public async Task DeleteAsync(int id)
    {
        var index = movies.FindIndex(movie => movie.Id == id);
        movies.RemoveAt(index);

        await Task.CompletedTask;
    }
}