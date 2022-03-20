using System.ComponentModel.DataAnnotations;

namespace MyMoviesApi.Models;

public class MovieDTO
{
    [Key]
    [Required]
    public int id {get; set;}
    
    [Required]
    public string title {get; set;} = null!;
}