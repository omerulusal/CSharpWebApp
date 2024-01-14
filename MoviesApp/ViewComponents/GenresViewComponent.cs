using Microsoft.AspNetCore.Mvc;
using MoviesApp.Models;

namespace MoviesApp.ViewComponents
{
    public class GenresViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke()
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
}
