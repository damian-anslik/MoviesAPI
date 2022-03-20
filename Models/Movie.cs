using System.ComponentModel.DataAnnotations;

namespace MyMoviesApi.Models;

public class Movie
{
    [Key]  
    public int id {get; set;}
    
    [Required]
    [MinLength(1, ErrorMessage = "Movie title cannot be empty")]
    public string title {get; set;} = null!;
    
    [Required]
    public Genre genre {get; set;}
    
    [Required]
    public Certification certification {get; set;}
    
    [Required]
    public DateTime releaseDate {get; set;}
    
    [Range(1, 10, ErrorMessage = "Movie rating can only be between one and ten")]
    public int rating {get; set;}
}

