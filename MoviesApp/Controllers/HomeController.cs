using Microsoft.AspNetCore.Mvc;
using MoviesApp.Data;
using MoviesApp.Models;
using System.Diagnostics;

namespace MoviesApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var model = new HomePageViewModel
        {
            PopularMovies = MovieRepository.Movies
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
