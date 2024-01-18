using MoviesApp.Entity;
using MoviesApp.Models;
using System.Collections.Generic;
using System.Linq;
namespace MoviesApp.Data
{
    public class GenreRepository
    {
        private static readonly List<Genre> _genres = null;
        //_genres adında bir liste alanı oluşturur.Film türlerini içerir ve readonly olduğu için sadece bir kere başlatılabilir.
        static GenreRepository()//constructor metod
        {
            _genres = new List<Genre>()
            {
                new Genre(){GenreId = 1, Name = "Action"},
                new Genre(){GenreId = 2, Name = "Comedy"},
                new Genre(){GenreId = 3, Name = "Drama"},
                new Genre(){GenreId = 4, Name = "Horror"},
                new Genre(){GenreId = 5, Name = "Romance"},
                new Genre(){GenreId = 6, Name = "Thriller"},
            };
        }
        public static List<Genre> Genres
        {
            get
            {
                return _genres;
            }
        }
        public static void Add(Genre genre)//Genre veri tipinde yeni bir tur eklenir.
        {
            _genres.Add(genre);
        }
        public static Genre GetById(int id)//belirli bir turun idsine göre arama yapmak için kullanılır.
        {
            return _genres.FirstOrDefault(g => g.GenreId == id);
        }
    }
}
