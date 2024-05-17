using Microsoft.EntityFrameworkCore;
using MovieStore.Api.Repositories;

namespace MovieStore.Api.Data;

public static class DataExtensions
{
    public static void InitializeDb(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<MovieStoreContext>();
        dbContext.Database.Migrate();
    }

    public static IServiceCollection AddRepositories(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        string? connString = configuration.GetConnectionString("MovieStoreContext");
        services.AddDbContextPool<MovieStoreContext>(options => options.UseMySql(connString, ServerVersion.AutoDetect(connString)))
        .AddScoped<IMoviesRepository, EntityFrameworkMoviesRepository>();

        return services;

    }
}