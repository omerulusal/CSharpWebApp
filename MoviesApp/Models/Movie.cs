using System.ComponentModel;

namespace MoviesApp.Models;

public class Movie
{
    public int MovieId { get; set; }
    public string Title { get; set; }
    [DisplayName("Baslik")]//Title yerine ekranda Baslik yazar.
    public string Description { get; set; }
    public string Director { get; set; }
    public string[] Actors { get; set; }
    public string ImageUrl { get; set; }
    public int GenreId { get; set; }
}
