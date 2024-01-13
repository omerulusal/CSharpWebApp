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
        ViewBag.Filmbasligi = filmbasligi;
        ViewBag.FilmAciklama = filmAciklama;
        ViewBag.FilmYonetmen = filmYonetmen;
        ViewBag.FilmOyuncular = filmOyuncular;
        return View();
    }
    public IActionResult About()
    {
        return View();
    }
}
