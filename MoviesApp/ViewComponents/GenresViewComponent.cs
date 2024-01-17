using Microsoft.AspNetCore.Mvc;
using MoviesApp.Data;
using MoviesApp.Models;

namespace MoviesApp.ViewComponents;

public class GenresViewComponent : ViewComponent
{


    private readonly MovieContext _context;
    public GenresViewComponent(MovieContext context)
    {
        _context = context;
    }


    public IViewComponentResult Invoke()
    {
        ViewBag.SelectedGenre = RouteData?.Values["genre"];
        return View(_context.Genres.ToList());
    }
}
