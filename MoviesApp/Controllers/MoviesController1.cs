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
    //localhost:5000/movies/list/id
    public IActionResult List(int? id, string q)
    {

        //var controller = RouteData.Values["controller"];
        //var action = RouteData.Values["action"];
        //var genreid = RouteData.Values["id"];


        //var movies = MovieRepository.Movies;
        var movies= _context.Movies.AsQueryable();

        if (id != null)
        {
            movies = movies.Where(m => m.GenreId == id);
        }
        if (!string.IsNullOrEmpty(q))
        {
            movies = movies.Where(m =>
                m.Title.ToLower().Contains(q.ToLower()) ||
                m.Description.ToLower().Contains(q.ToLower()));
        }

        var model = new MoviesViewModel()
        {
            Movies = movies.ToList(),
        };
        return View(model);//list sayfasına modeli gonderdim
    }

    //localhost:5000/movies/details
    public IActionResult Details(int id)//id 
    {
        return View(_context.Movies.Find(id));
    }
    public IActionResult Create()
    {
        ViewBag.Genres = new SelectList(_context.Genres.ToList(), "GenreId", "Name");
        return View();
    }

    [HttpPost]//film eklerken create sayfasında post metodu kullandım
    public IActionResult Create(Movie m)
    {
        if (ModelState.IsValid)
        {
            //MovieRepository.Add(m);//Movie turunde yeni filmi ekledim
            _context.Movies.Add(m);
            _context.SaveChanges();
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

    [HttpPost]
    public IActionResult Edit(Movie m)
    {
        if (ModelState.IsValid)
        {
            //MovieRepository.Edit(m);
            _context.Movies.Update(m);
            _context.SaveChanges();
            return RedirectToAction("Details", "Movies", new { @id = m.MovieId });
        }
        ViewBag.Genres = new SelectList(_context.Genres.ToList(), "GenreId", "Name");
        return View(m);
    }


    [HttpPost]
    public IActionResult Delete(int MovieId,string Title)
    {
        //MovieRepository.Delete(MovieId);
        var entity = _context.Movies.Find(MovieId);
        _context.Movies.Remove(entity);
        _context.SaveChanges();
        TempData["Message"] = $"{Title} isimli film silindi.";
        return RedirectToAction("List");
    }
}
