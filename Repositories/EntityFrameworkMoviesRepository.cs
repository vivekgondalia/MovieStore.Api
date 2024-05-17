using Microsoft.EntityFrameworkCore;
using MovieStore.Api.Data;
using MovieStore.Api.Entities;

namespace MovieStore.Api.Repositories
{
    public class EntityFrameworkMoviesRepository : IMoviesRepository
    {
        private readonly MovieStoreContext dbContext;

        public EntityFrameworkMoviesRepository(MovieStoreContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Movie> GetAll()
        {
            return dbContext.Movies.AsNoTracking().ToList();
        }

        public Movie? GetById(int id)
        {
            return dbContext.Movies.Find(id);
        }

        public void Create(Movie newMovie)
        {
            dbContext.Movies.Add(newMovie);
            dbContext.SaveChanges();
        }

        public void Update(Movie updatedMovie)
        {
            dbContext.Update(updatedMovie);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            dbContext.Movies.Where(movie => movie.Id == id)
                .ExecuteDelete();    
        }

    }
}