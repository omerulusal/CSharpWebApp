using Microsoft.EntityFrameworkCore;
using MoviesApp.Entity;

namespace MoviesApp.Data;

public class MovieContext : DbContext
{
    public MovieContext(DbContextOptions<MovieContext> options) : base(options)//constructor metod
    {
    }
    public DbSet<Movie> Movies { get; set; }//veritbanındaki Movies tablosuna erisim saglanır.
    public DbSet<Genre> Genres { get; set; }//veritbanındaki Genres tablosuna erisim saglanır.
}
//DbContext, Entity Framework Core tarafından sağlanan bir temel sınıftır ve veritabanı işlemleri için kullanılır.