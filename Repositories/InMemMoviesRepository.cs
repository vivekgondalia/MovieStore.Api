
using MovieStore.Api.Entities;

namespace MovieStore.Api.Repositories;

public class InMemMoviesRepository
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

    public IEnumerable<Movie> GetAll()
    {
        return movies;
    }

    public Movie? GetById(int id)
    {
        return movies.Find(movie => movie.Id == id);
    }

    public void Create(Movie newMovie)
    {
        newMovie.Id = movies.Max(movie => movie.Id) + 1;
        movies.Add(newMovie);
    }

    public void Update(Movie updatedMovie)
    {
        var index = movies.FindIndex(movie => movie.Id == updatedMovie.Id);
        movies[index] = updatedMovie;
    }

    public void Delete(int id)
    {
        var index = movies.FindIndex(movie => movie.Id == id);
        movies.RemoveAt(index);
    }
}