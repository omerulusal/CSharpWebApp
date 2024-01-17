using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApp.Data;
using MoviesApp.Models;

namespace MoviesApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly MovieContext _context;
        public AdminController(MovieContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MovieList()
        {
            return View(new AdminMoviesViewModel
            {
                Movies = _context.Movies.ToList()
            });
        }
        public IActionResult MovieUpdate(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = _context.Movies.Select(mx => new AdminEditMovieViewModel
            {
                MovieId = mx.MovieId,
                Title = mx.Title,
                Description = mx.Description,
                ImageUrl = mx.ImageUrl,
            }).FirstOrDefault(me => me.MovieId == id);

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
            entity.Title = model.Title;
            entity.Description = model.Description;
            entity.ImageUrl = model.ImageUrl;
            _context.SaveChanges();
            return RedirectToAction("MovieList");
        }

    }
}
