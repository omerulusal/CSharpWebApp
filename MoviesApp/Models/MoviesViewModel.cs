using MoviesApp.Entity;

namespace MoviesApp.Models;

public class MoviesViewModel
    //bu class icerisinde iki adet liste turunde veri barındırıyor.
    //1. models klasörundeki Movie.cs 2. ise modelsteki Genre.cs listesi
{
    public List<Movie> Movies { get; set; }
}

//hem Movie hem de Genre modelini bir ortak modele ekledim.