using Microsoft.EntityFrameworkCore;
using MoviesApp.Entity;

namespace MoviesApp.Data;

public class MovieContext : DbContext
{
    public MovieContext(DbContextOptions<MovieContext> options) : base(options)
    {
    }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Genre> Genres { get; set; }
    
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlite("Data Source=movies.db");
    //}
}
