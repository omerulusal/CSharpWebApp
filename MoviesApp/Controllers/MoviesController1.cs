using Microsoft.AspNetCore.Mvc;
using MoviesApp.Data;
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
        //localhost:5000/movies/list/id
        public IActionResult List(int? id, string q)
        {

            //var controller = RouteData.Values["controller"];
            //var action = RouteData.Values["action"];
            //var genreid = RouteData.Values["id"];


            var movies = MovieRepository.Movies;
            if (id != null)
            {
                movies = movies.Where(m => m.GenreId == id).ToList();
            }
            if (!string.IsNullOrEmpty(q))
            {
                movies = movies.Where(m =>
                    m.Title.ToLower().Contains(q.ToLower()) ||
                    m.Description.ToLower().Contains(q.ToLower())).ToList();
            }

            var model = new MoviesViewModel()
            {
                Movies = movies,
            };
            return View(model);//list sayfasına modeli gonderdim
        }

        //localhost:5000/movies/details
        public IActionResult Details(int id)//id 
        {
            return View(MovieRepository.GetById(id));
        }
    }
}
