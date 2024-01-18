using Microsoft.EntityFrameworkCore;

namespace MoviesApp.Data;

public static class DataSeeding
{
    public static void Seed(IApplicationBuilder app)
    {
        var scope = app.ApplicationServices.CreateScope();
        var context = scope.ServiceProvider.GetService<MovieContext>();
        context.Database.Migrate();//mevcut veritabanını en son duruma getirmek için pending olan tüm migration'ları uygular.

        if (context.Database.GetPendingMigrations().Count() == 0)//bekleyen bir migration yoksa calışır.
        {

            if (context.Movies.Count() == 0)//Movies tablosunda herhangi bir kayıt yoksa.
            {
                context.Movies.AddRange(MovieRepository.Movies);
            }

            if (context.Genres.Count() == 0)//Genres tablosunda herhangi bir kayıt yoksa.
            {
                context.Genres.AddRange(GenreRepository.Genres);
                //veri tabanına GenreRepository icerisindeki kayıtları ekler.
            }
            context.SaveChanges();
        }
    }
}

/*!
Bu class veritabanını oluşturmak ve örnek verilerle doldurmak için kullanılacak bir veritabanı
başlatma(seeding) işlemini gerçekleştiren bir sınıfı temsil eder.
*/