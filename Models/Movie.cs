using System.ComponentModel.DataAnnotations;

namespace MyMoviesApi.Models;

public class Movie
{
    [Key]  
    public int id {get; set;}
    
    [Required]
    [MinLength(1, ErrorMessage = "Movie title length cannot be zero")]
    public string title {get; set;} = null!;
    
    [Required]
    public Genre genre {get; set;}
    
    [Required]
    public Certification certification {get; set;}
    
    [Required]
    public DateTime releaseDate {get; set;}
    
    [Range(1, 10, ErrorMessage = "Movie rating must be in range 1 to 10")]
    public int? rating {get; set;}
}

