namespace MyMoviesApi.Models;

public class Movie
{
    public int id {get; set;}
    public string title {get; set;}
    public string genre {get; set;}
    public Certification certification {get; set;}
    public DateTime releaseDate {get; set;}
    public int rating {get; set;}

    public Movie(int _id, string _title, Genre _genre, Certification _certification, string _releaseDateString, int _rating)
    {
        id = _id;
        title = _title;
        genre = Enum.GetName(typeof(Genre), _genre)!.ToLowerInvariant();
        certification = _certification;
        releaseDate = DateTime.Parse(_releaseDateString); 
        rating = _rating;
    }
}

