using Microsoft.AspNetCore.Mvc;

namespace MoviesApp.Controllers
{
    public class MoviesController : Controller
    {
        //localhost:5000/movies/list
        public string List()
        {
            return "Film Listesi";
        }
        //localhost:5000/movies/details
        public string Details()
        {
            return "Film Detayları";
        }
    }
}
