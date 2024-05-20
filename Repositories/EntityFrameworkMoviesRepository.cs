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

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await dbContext.Movies.AsNoTracking().ToListAsync();
        }

        public async Task<Movie?> GetByIdAsync(int id)
        {
            return await dbContext.Movies.FindAsync(id);
        }

        public async Task CreateAsync(Movie newMovie)
        {
            dbContext.Movies.Add(newMovie);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Movie updatedMovie)
        {
            dbContext.Update(updatedMovie);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await dbContext.Movies.Where(movie => movie.Id == id)
                .ExecuteDeleteAsync();
        }

    }
}