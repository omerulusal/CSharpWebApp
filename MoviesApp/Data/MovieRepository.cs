using MoviesApp.Entity;
using MoviesApp.Models;
using System.Collections.Generic;
using System.Linq;
namespace MoviesApp.Data;

public class MovieRepository
{
    private static readonly List<Movie> _movies = null;
    //_movies, Liste olarak film verilerini içerir,readonly olduğu için sadece bir kere başlatılabilir.
    static MovieRepository()//constructor metod _movies listesini başlatır ve başlangıç verilerini içerir.
    {
        _movies = new()
        {
            new (){MovieId = 1, Title = "The Godfather",Description="GodFatherDesc",Director="Omer",ImageUrl="avengers.jpeg",GenreId=1 },
            new (){MovieId= 2, Title= "The Dark Knight",Description="Dark Knight",Director="Omer" ,ImageUrl="avengers.jpeg",GenreId = 2 },
            new (){MovieId= 3, Title= "Forrest Gump",Description="ForestDesc",Director="Omer" ,ImageUrl="avengers.jpeg" , GenreId = 3},
        };
    }
    public static List<Movie> Movies
    {
        get
        {
            return _movies; //_movies listesine dışarıdan erişim sağlar.
        }
    }
    public static void Add(Movie movie)
    {
        movie.MovieId = _movies.Count() + 1;
        _movies.Add(movie);
    }
    public static Movie GetById(int id)
    {
        return _movies.FirstOrDefault(m => m.MovieId == id);
        //disarıdan gelen id paramının _moviestaki herhangi bir filmin idsine eşit olup olmadıgını kontrol eder.
    }

    public static void Edit(Movie m)
    {
        foreach (var movie in _movies)//movies listesindeki herbir movie'yi dondum
        {
            if (movie.MovieId == m.MovieId)
            {
                movie.Title = m.Title;
                movie.Description = m.Description;
                movie.Director = m.Director;
                movie.GenreId = m.GenreId;
                movie.ImageUrl = m.ImageUrl;
                break;
            }
        }
    }

    public static void Delete(int MovieId)
    {
        var movie = GetById(MovieId);

        if (movie != null)
        {
            _movies.Remove(movie);
        }
    }
}
