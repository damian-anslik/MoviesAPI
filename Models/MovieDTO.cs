namespace MyMoviesApi.Models;

public class MovieDTO
{
    public int id {get; set;}
    public string title {get; set;} = null!;
    
    public MovieDTO(int _id, string _title)
    {
        id = _id;
        title = _title;
    }
}