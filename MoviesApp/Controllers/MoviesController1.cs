using Microsoft.AspNetCore.Mvc;

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
            return View();

        }
        //localhost:5000/movies/details
        public IActionResult Details()
        {
            return View();
        }
    }
}
