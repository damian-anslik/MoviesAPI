using System.ComponentModel.DataAnnotations;

namespace MyMoviesApi.Models;

public class MovieDTO
{
    [Key]
    public int id {get; set;}
    
    [Required]
    public string title {get; set;} = null!;
}