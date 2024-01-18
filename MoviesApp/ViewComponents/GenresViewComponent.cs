using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using MoviesApp.Data;
using MoviesApp.Models;

namespace MoviesApp.ViewComponents;

public class GenresViewComponent : ViewComponent
{


    private readonly MovieContext _context;
    public GenresViewComponent(MovieContext context)
    {
        _context = context;//dbden gelen icerigi _contexte atadım
    }


    public IViewComponentResult Invoke()
    {
        ViewBag.SelectedGenre = RouteData?.Values["genre"];
        //route verileri içindeki "genre" değerini ViewBag.SelectedGenre özelliğine atar
        return View(_context.Genres.ToList());
        //_context üzerinden tüm film türlerini alır ve bir view'a geçirir. 
    }
}