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

        var m = new Movie();//Movie.cs class�ndan nesne turettim
        m.Title = filmbasligi;
        m.Description = filmAciklama;
        m.Director = filmYonetmen;
        m.Actors = filmOyuncular;
        m.ImageUrl = "avengers.jpeg";

        return View(m);
        //m ad�yla olusturdugum modeli Movie klas�rundeki Index.cshtml ye yollad�m.
    }
    public IActionResult About()
    {
        return View();
    }
}
