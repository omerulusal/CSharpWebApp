using Microsoft.AspNetCore.Mvc;
using MoviesApp.Data;
using MoviesApp.Entity;
using MoviesApp.Models;
using System.Diagnostics;
using System.Linq;

namespace MoviesApp.Controllers;

public class HomeController : Controller //HomeController,Controller sýnýfýndan türetilmiþtir,
{


    private readonly MovieContext _context;
    public HomeController(MovieContext context)
    //contructor oluþturdum MovieContext tipinde context parametresi alýr
    {
        _context = context;
        //MovieContextin ornegi alýnýp _context degiskenine atandý _context Dbyi temsil eder
    }


    public IActionResult Index()//Home klasörundeki Index.cshtml calýþýr
    {
        var model = new HomePageViewModel
        {
            PopularMovies = _context.Movies.ToList()
            //HomePageViewModeldeki PopularMovies = _context ile Dbdeki Movies Tablosunun listelenmiþ hali
        };
        return View(model);//oluþturulan yeni model index.cshtmlye gonderilir.
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
        return View(turListesi);//oluþturulan yeni turListesi About.cshtmlye gonderilir.
    }
}
