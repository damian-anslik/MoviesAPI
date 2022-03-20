using Microsoft.AspNetCore.Mvc;
using MyMoviesApi.Models;

namespace MyMoviesApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class MoviesController
{
    private List<Movie> movies { get; set; }
    public MoviesController()
    {
        movies = new List<Movie>(){
            new Movie(){
                id = 1,
                title = "Star Wars Episode 1: The Phantom Menace", 
                genre = Genre.COMEDY, 
                certification = Certification.MATURE, 
                releaseDate = DateTime.Parse("1999-05-19"), 
                rating = 2
                },
            new Movie(){
                id = 2,
                title = "Star Wars Episode 2: Attack of the Clones", 
                genre = Genre.DOCUMENTARY, 
                certification = Certification.PA, 
                releaseDate = DateTime.Parse("2002-05-16"), 
                rating = 4
                },
            new Movie(){
                id = 3,
                title = "Star Wars Episode 3: Revenge of the Sith", 
                genre = Genre.COMEDY, 
                certification = Certification.MATURE, 
                releaseDate = DateTime.Parse("2005-05-19"), 
                rating = 5
                },
            new Movie(){
                id = 4,
                title = "Star Wars Episode 4: A New Hope", 
                genre = Genre.SCIFI, 
                certification = Certification.MATURE, 
                releaseDate = DateTime.Parse("1977-05-25"), 
                rating = 8
                },
            new Movie(){
                id = 5,
                title = "Star Wars Episode 5: The Empire Strikes Back", 
                genre = Genre.SCIFI, 
                certification = Certification.MATURE, 
                releaseDate = DateTime.Parse("1980-05-21"), 
                rating = 9
                },
            new Movie(){
                id = 6,
                title = "Star Wars Episode 6: Return of the Jedi", 
                genre = Genre.SCIFI, 
                certification = Certification.MATURE, 
                releaseDate = DateTime.Parse("1983-05-25"), 
                rating = 8
                },
        };
    }

    [HttpGet("all")]
    public ActionResult<List<Movie>> GetAllMovies()
    {
        var moviesSorted = movies
            .OrderByDescending(movie => movie.releaseDate)
            .ToList();
        return new OkObjectResult(moviesSorted);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Movie))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetMovieById(int id)
    {
        var movie = movies
            .Find(movie => movie.id == id);
        if (movie == null)
        {
            return new NotFoundResult();
        }
        else return new OkObjectResult(movie);
    }

    [HttpGet("search/{keyword}")]
    public ActionResult<List<MovieDTO>> SearchMoviesByKeyword(string keyword)
    {
        var results = movies
            .FindAll(movie => movie.title.ToLower().Split(" ").Contains(keyword)) // this is hacky...
            .Select(movie => new MovieDTO(){
                id = movie.id, 
                title = movie.title
            })
            .ToList();
        return new OkObjectResult(results);
    }
}
