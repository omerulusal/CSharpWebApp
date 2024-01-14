using Microsoft.AspNetCore.Mvc;
using MoviesApp.Data;
using MoviesApp.Models;

namespace MoviesApp.ViewComponents
{
    public class GenresViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedGenre = RouteData?.Values["genre"];
            return View(GenreRepository.Genres);
        }
    }
}
