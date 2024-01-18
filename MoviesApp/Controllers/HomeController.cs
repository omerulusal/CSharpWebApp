using Microsoft.AspNetCore.Mvc;
using MoviesApp.Data;
using MoviesApp.Entity;
using MoviesApp.Models;
using System.Diagnostics;
using System.Linq;

namespace MoviesApp.Controllers;

public class HomeController : Controller //HomeController,Controller s�n�f�ndan t�retilmi�tir,
{


    private readonly MovieContext _context;
    public HomeController(MovieContext context)
    //contructor olu�turdum MovieContext tipinde context parametresi al�r
    {
        _context = context;
        //MovieContextin ornegi al�n�p _context degiskenine atand� _context Dbyi temsil eder
    }


    public IActionResult Index()//Home klas�rundeki Index.cshtml cal���r
    {
        var model = new HomePageViewModel
        {
            PopularMovies = _context.Movies.ToList()
            //HomePageViewModeldeki PopularMovies = _context ile Dbdeki Movies Tablosunun listelenmi� hali
        };
        return View(model);//olu�turulan yeni model index.cshtmlye gonderilir.
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
        return View(turListesi);//olu�turulan yeni turListesi About.cshtmlye gonderilir.
    }
}
