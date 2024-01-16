using System.ComponentModel.DataAnnotations;

namespace MoviesApp.Entity;

public class Genre
{
    public int GenreId { get; set; }
    [Required]
    public string Name { get; set; }
}
