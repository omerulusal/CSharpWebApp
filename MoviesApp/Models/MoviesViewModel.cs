using MoviesApp.Entity;

namespace MoviesApp.Models;

public class MoviesViewModel
//bu class icerisinde liste turunde Movie verisi barındırıyor.(models klasörundeki Movie.cs)
{
    public List<Movie> Movies { get; set; }
}