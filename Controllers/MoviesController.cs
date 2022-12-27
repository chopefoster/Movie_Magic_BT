using Microsoft.AspNetCore.Mvc;
using Movie_Magic.Models;
using Movie_Magic.Repositories;
using System.Linq;
using System.Net;

namespace Movie_Magic.Controllers;

[ApiController]
[Route("[controller]")]
public class MoviesController : ControllerBase
{
    private readonly ILogger<MoviesController> _logger;
    private readonly IMovieRepository _movieRepository;
    public MoviesController(ILogger<MoviesController> logger, IMovieRepository repo)
    {
        _logger = logger;
        _movieRepository = repo;
    }

    [HttpGet]
    public IEnumerable<Movie> GetMovies()
    {
        return _movieRepository.GetAllMovies();
    }

    [HttpGet]
    [Route("{movieId:int}")]
    public Movie? GetMovieById(int movieId) 
    {
        var movie = _movieRepository.GetMovieById(movieId);
        if (movie == null) {
            Response.StatusCode = (int) HttpStatusCode.NotFound;
            return null;
        }
        return movie;
    }
}
