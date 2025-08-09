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
        Task<Movie?> GetMovieByIdAsync(string id);
        Task<Movie?> CreateMovieAsync(Movie movie);
        Task<Movie?> UpdateMovieAsync(string id, Movie movie);
        Task<Movie?> DeleteMovieAsync(string id);  
    }
}