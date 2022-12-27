using Microsoft.AspNetCore.Mvc;
using Movie_Magic.Models;
using System.Linq;
using System.Net;

namespace Movie_Magic.Controllers;

[ApiController]
[Route("[controller]")]
public class MoviesController : ControllerBase
{
    private static readonly Movie[] mockMovies = new[]
    {
        new Movie { MovieId = 1, Name = "Cars", Rating = 4},
        new Movie { MovieId = 2, Name = "Jurassic Park", Rating = 5},
        new Movie { MovieId = 3, Name = "Back to the Future", Rating = 5}        
    };

    private readonly ILogger<MoviesController> _logger;

    public MoviesController(ILogger<MoviesController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<Movie> GetMovies()
    {
        return mockMovies;
    }

    [HttpGet]
    [Route("{movieId:int}")]
    public Movie? GetMovieById(int movieId) 
    {
        var movie = mockMovies.FirstOrDefault(m => m.MovieId == movieId);
        if (movie == null) {
            Response.StatusCode = (int) HttpStatusCode.NotFound;
            return null;
        }
        return movie;
    }
}
