using Microsoft.EntityFrameworkCore;
using MovieStore.Api.Entities;

namespace MovieStore.Api.Data
{
    public class MovieStoreContext : DbContext
    {
        public MovieStoreContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Movie> Movies => Set<Movie>();
    }
}