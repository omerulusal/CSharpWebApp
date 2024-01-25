using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoviesApp.Data;
using MoviesApp.Entity;
using MoviesApp.Models;

namespace MoviesApp.Controllers;

public class MoviesController : Controller

{
    private readonly MovieContext _context;
    public MoviesController(MovieContext context)
    {
        _context = context;
    }

    /*
     normalde localhost:5000/movies yazarsam sayfa bulunamadı hatası alırdım cunku urlde en az 2 bolme 
     olmaliydı bunu Index erisim methodu ekleyince /movies icin varsayilan index sayfası oldu.
     */
    public IActionResult Index()
    {
        return View();
    }

    //localhost:5000/movies/list
    public IActionResult List(int? id, string q)
    {
        var movies= _context.Movies.AsQueryable();

        if (id != null)
        {
            movies = movies.Where(m => m.GenreId == id);
            //dbden gelen filmlerin icerisinden GenreId si param olarak gelen idye esit olanı alıp movies a atadım
        }
        if (!string.IsNullOrEmpty(q))//sorgu param boş degilse calısır.
        {
            movies = movies.Where(m =>
                m.Title.ToLower().Contains(q.ToLower()) ||
                m.Description.ToLower().Contains(q.ToLower()));

            //dbden gelen Title veya Description propertylerinin kucuk harfe cevrilmiş halini alıp q parametresi ile karsılastırılır
        }

        var model = new MoviesViewModel()
        {
            Movies = movies.ToList(),//MoviesViewModel in Movies Propertysi = Dbdeki moviesin listelenmiş hali
        };
        return View(model);
    }

    public IActionResult Details(int id)
    {
        return View(_context.Movies.Find(id));
        //disarıdan girdigim id ye ait filmi bul ve Details.cshtml sayfasına yolla
    }
    public IActionResult Create()
    {
        ViewBag.Genres = new SelectList(_context.Genres.ToList(), "GenreId", "Name");
        // _context.Genres.ToList(): Veritabanından tüm film türlerini liste olarak alır.
        // "GenreId", "Name": SelectList için kullanılacak değerlerin belirlenmesi.
        return View();
    }

    [HttpPost]//film eklerken create sayfasında post metodu kullandım
    public IActionResult Create(Movie m)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Add(m);//db deki movies tablosuna gelen filmi ekledim
            _context.SaveChanges();//ekledikten sonra kaydettim
            TempData["Message"] = $"{m.Title} isimli film eklendi.";
            return RedirectToAction("List");//List contorllerına yonlendirdim
        }
        ViewBag.Genres = new SelectList(_context.Genres.ToList(), "GenreId", "Name");
        return View();
    }

    public IActionResult Edit(int id)
    {
        ViewBag.Genres = new SelectList(_context.Genres.ToList(), "GenreId", "Name");
        return View(_context.Movies.Find(id));
    }

    [HttpPost] //action metodunun yalnızca HTTP POST isteklerine yanıt vermesini sağlar.
    public IActionResult Edit(Movie m)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Update(m);//dbdeki movies tablosuna gelen filmi gunceller
            _context.SaveChanges();
            return RedirectToAction("Details", "Movies", new { @id = m.MovieId });
        }
        ViewBag.Genres = new SelectList(_context.Genres.ToList(), "GenreId", "Name");
        return View(m);
    }


    [HttpPost]
    public IActionResult Delete(int MovieId,string Title)
    {
        var entity = _context.Movies.Find(MovieId);
        _context.Movies.Remove(entity);
        _context.SaveChanges();
        TempData["Message"] = $"{Title} isimli film silindi.";
        return RedirectToAction("List");
    }
}

//TempData, bir istekten diğerine veri taşımak için kullanılır.
//ViewBag: controller action'ından view'e veri geçişini sağlar.