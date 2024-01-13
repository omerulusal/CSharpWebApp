using Microsoft.AspNetCore.Mvc;
using MoviesApp.Models;
using System.Diagnostics;

namespace MoviesApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        string filmbasligi = "Avengers";
        string filmAciklama = "Avengers: Endgame";
        string filmYonetmen = "OmerUlusal";
        string[] filmOyuncular = {
            "Robert Downey Jr"," Chris Evans","Scarlett Johansson,","Tom Holland",
        };

        var m = new Movie();//Movie.cs classýndan nesne turettim
        m.Title = filmbasligi;
        m.Description = filmAciklama;
        m.Director = filmYonetmen;
        m.Actors = filmOyuncular;
        m.ImageUrl = "avengers.jpeg";

        return View(m);
        //m adýyla olusturdugum modeli Movie klasörundeki Index.cshtml ye yolladým.
    }
    public IActionResult About()
    {
        return View();
    }
}
