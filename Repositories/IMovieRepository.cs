using System.Collections.Generic;
using Movie_Magic.Models;

namespace Movie_Magic.Repositories;

{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAllMovies();
        Movie GetMovieById(int movieId);
        Movie CreateMovie(Movie newMovie);
        Movie UpdateMovie(Movie newMovie);
        void DeleteMovie (int movieId);
    }
}