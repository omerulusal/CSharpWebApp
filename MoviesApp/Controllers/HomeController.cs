using Microsoft.AspNetCore.Mvc;
using MoviesApp.Data;
using MoviesApp.Entity;
using MoviesApp.Models;
using System.Diagnostics;
using System.Linq;

namespace MoviesApp.Controllers;

public class HomeController : Controller
{


    private readonly MovieContext _context;
    public HomeController(MovieContext context)
    {
        _context = context;
    }


    public IActionResult Index()
    {
        var model = new HomePageViewModel
        {
            PopularMovies = _context.Movies.ToList()
        };
        return View(model);
    }
    public IActionResult About()
    {
        var turListesi = new List<Genre>(){
                new Genre {Name="Comedy"},
                new Genre {Name="Action"},
                new Genre {Name="Drama"},
                new Genre {Name="Romance"},
                new Genre {Name="War"}
            };
        return View(turListesi);
    }
}
