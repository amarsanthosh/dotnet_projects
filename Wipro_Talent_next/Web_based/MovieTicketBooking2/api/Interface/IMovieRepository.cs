using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interface
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetAllMoviesAsync();
        Task<Movie?> GetMovieByIdAsync(int id);
        Task<Movie?> CreateMovieAsync(Movie movie);
        Task<Movie?> UpdateMovieAsync(int id, Movie movie);
        Task<Movie?> DeleteMovieAsync(int id);  
    }
}