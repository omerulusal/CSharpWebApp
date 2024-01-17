using Microsoft.EntityFrameworkCore;

namespace MoviesApp.Data;

public static class DataSeeding
{
    public static void Seed(IApplicationBuilder app)
    {
        var scope = app.ApplicationServices.CreateScope();
        var context = scope.ServiceProvider.GetService<MovieContext>();
        context.Database.Migrate();

        if (context.Database.GetPendingMigrations().Count() == 0)
        {

            if (context.Movies.Count() == 0)
            {
                context.Movies.AddRange(MovieRepository.Movies);
            }

            if (context.Genres.Count() == 0)
            {
                context.Genres.AddRange(GenreRepository.Genres);
            }
            context.SaveChanges();
        }
    }
}
