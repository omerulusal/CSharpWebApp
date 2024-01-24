using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.EntityFrameworkCore;
using MoviesApp.Data;
using MoviesApp.Models;

namespace MoviesApp.Controllers
{
    public class AdminController : Controller //AdminController,Controller sınıfından türetilmiştir,
    {
        private readonly MovieContext _context;
        public AdminController(MovieContext context)
        //contructor oluşturdum MovieContext tipinde context parametresi alır
        {
            _context = context;//MovieContextin ornegi alınıp _context degiskenine atandı
        }
        public IActionResult Index()
        {
            return View();
            // /Admin/Index e GET yapılınca Viewsteki Admin klasörunde bulunan Index.cshtmlye gider
        }
        public IActionResult MovieList()
        {
            //View icerisinden veri aktardım
            return View(new AdminMoviesViewModel
            {
                Movies = _context.Movies.ToList()
                //AdminMoviesViewModelindeki Movies = _context ile Dbdeki Movies Tablosunun listelenmiş hali
            });
            // /Admin/MovieList e GET yapılınca Viewsteki Admin klasörunde bulunan MovieList.cshtmlye gider

        }
        public IActionResult MovieUpdate(int? id) //! /Admin/MovieUpdate/{id}
        {
            if (id == null)
            {
                return NotFound();//urlde id param yoksa Hata sayfası doner.
            }
            var entity = _context.Movies.Select(mx => new AdminEditMovieViewModel
            //dbden gelen herbir film icin bir tane AdminEditMovieViewModel olusturulur
            //AdminEditMovieViewModeldeki her bir property,dbden gelen film bilgileri ile doldurulur
            {
                MovieId = mx.MovieId,
                Title = mx.Title,
                Description = mx.Description,
                ImageUrl = mx.ImageUrl,
            }).FirstOrDefault(me => me.MovieId == id);

            ViewBag.Genres = _context.Genres.ToList();
            //ViewBag aracılığıyla Genres adlı veri de view'e aktarılır.
            if (entity == null)
            {
                return NotFound();
            }
            return View(entity);

        }


        [HttpPost]
        public IActionResult MovieUpdate(AdminMovieViewModel model)
        {
            var entity = _context.Movies.Find(model.MovieId);
            //Movies tablosu icerisinden gelen MovieId degerine gore veriyi bulur
            entity.Title = model.Title;
            entity.Description = model.Description;
            entity.ImageUrl = model.ImageUrl;
            _context.SaveChanges();
            return RedirectToAction("MovieList");
        }

    }
}

//private readonly:_context değişkeninin sadece bu classta erişilebilir ve değerinin değiştirilemeyeceğini belirtir. 