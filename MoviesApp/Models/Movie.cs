using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MoviesApp.Models;

public class Movie
{
    public int MovieId { get; set; }
    [DisplayName("Baslik")]//Title yerine ekranda Baslik yazar.
    [Required(ErrorMessage ="Film başlıgı ekle")]//Zorunlu
    [StringLength(50,MinimumLength =5,ErrorMessage ="5-50 karakter aralıgında olmalıdır")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Film Açıklaması ekle")]//Zorunlu
    public string Description { get; set; }
    [Required(ErrorMessage = "Film Yonetmeni ekle")]//Zorunlu
    public string Director { get; set; }
    public string[] Actors { get; set; }
    public string ImageUrl { get; set; }
    [Required]
    public int? GenreId { get; set; }
}
