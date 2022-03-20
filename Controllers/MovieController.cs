using Microsoft.AspNetCore.Mvc;
using MyMoviesApi.Models;

namespace MyMoviesApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MoviesController
{
    private List<Movie> movies {get; set;}
    public MoviesController()
    {
        movies = new List<Movie>(){
            new Movie(1, "Star Wars Episode 1: The Phantom Menace", Genre.COMEDY, Certification.MATURE, "1999-05-19", 2),
            new Movie(2, "Star Wars Episode 2: Attack of the Clones", Genre.DOCUMENTARY, Certification.PA, "2002-05-16", 1),
            new Movie(3, "Star Wars Episode 3: Revenge of the Sith", Genre.COMEDY, Certification.MATURE, "2005-05-19", 5),
            new Movie(4, "Star Wars Episode 4: A New Hope", Genre.SCIFI, Certification.MATURE, "1977-05-25", 8),
            new Movie(5, "Star Wars Episode 5: The Empire Strikes Back", Genre.SCIFI, Certification.MATURE, "1980-05-21", 9),
            new Movie(6, "Star Wars Episode 6: Return of the Jedi", Genre.SCIFI, Certification.MATURE, "1983-05-25", 8),
        };
    }

    [HttpGet("all")]
    public ActionResult<List<Movie>> GetAllMovies()
    {
        var moviesSorted = movies
            .OrderByDescending(movie => movie.releaseDate)
            .ToList();
        return moviesSorted;
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
            .Select(movie => new MovieDTO(movie.id, movie.title))
            .ToList();
        return results;
    }
}
