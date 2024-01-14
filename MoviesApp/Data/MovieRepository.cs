using MoviesApp.Models;
using System.Collections.Generic;
using System.Linq;
namespace MoviesApp.Data
{
    public class MovieRepository
    {
        private static readonly List<Movie> _movies = null;
        static MovieRepository()
        {
            _movies = new()
            {
                new (){MovieId = 1, Title = "The Godfather",Description="GodFatherDesc",Director="Omer",Actors=new string[]{"Oyuncu1", "Oyuncu2" },ImageUrl="avengers.jpeg" },
                new (){MovieId= 2, Title= "The Dark Knight",Description="Dark Knight",Director="Omer",Actors= new string[]{ "Oyuncu1" , "Oyuncu2" } ,ImageUrl="avengers.jpeg" },
                new (){MovieId= 3, Title= "Forrest Gump",Description="ForestDesc",Director="Omer",Actors= new string[]{ "Oyuncu1" , "Oyuncu2" } ,ImageUrl="avengers.jpeg" },
            };
        }
        public static List<Movie> Movies
        {
            get
            {
                return _movies;
            }
        }
        public static void Add(Movie movie)
        {
            _movies.Add(movie);
        }
        public static Movie GetById(int id)
        {
            return _movies.FirstOrDefault(m => m.MovieId == id);
        }
    }
}
