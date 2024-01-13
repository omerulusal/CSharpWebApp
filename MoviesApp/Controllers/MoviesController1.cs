using Microsoft.AspNetCore.Mvc;
using MoviesApp.Models;

namespace MoviesApp.Controllers
{
    public class MoviesController : Controller

    {

        /*
         normalde localhost:5000/movies yazarsam sayfa bulunamadı hatası alırdım cunku urlde en az 2 bolme 
         olmaliydı bunu Index erisim methodu ekleyince /movies icin varsayilan index sayfası oldu.
         */
        public IActionResult Index()
        {
            return View();
        }

        //localhost:5000/movies/list
        public IActionResult List()
        {
            var filmListesi = new List<Movie>()
            {
                new Movie {Title = "Film1",Description="A1",Actors=new string[]{"john Doe","Jane Doe"},Director="OmerUlusal",ImageUrl="avengers.jpeg"},
                new Movie {Title = "Film2",Description="A1",Actors=new string[]{"john Doe","Jane Doe"},Director="OmerUlusal",ImageUrl="avengers.jpeg"},
                new Movie {Title = "Film3",Description="A1",Actors=new string[]{"john Doe","Jane Doe"},Director="OmerUlusal",ImageUrl="avengers.jpeg"}
            };
            return View(filmListesi);

        }
        //localhost:5000/movies/details
        public IActionResult Details()
        {
            return View();
        }
    }
}
