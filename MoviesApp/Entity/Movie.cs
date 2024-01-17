using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MoviesApp.Entity
{
    public class Movie
    {
        public int MovieId { get; set; }//Ef core bu alanı otomatik olrak PK id algılıyor
        [Required]
        public string? Title { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
        public string? Director { get; set; }
        public string? ImageUrl { get; set; }
        [Required]
        public int? GenreId { get; set; }
    }
}
