using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Movie;
using api.Interface;
using api.Models;
using Microsoft.AspNetCore.Hosting.Builder;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _context;
        public MovieRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //get all
        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            return await _context.Movie.ToListAsync();
        }

       //get by id
        public async Task<Movie?> GetMovieByIdAsync(string id)
        {
            var movie = await _context.Movie.FirstOrDefaultAsync(x => x.MovieId == id);
            return movie;
        }

        //Post
        public async Task<Movie?> CreateMovieAsync(Movie movie)
        {
            await _context.Movie.AddAsync(movie);
            await _context.SaveChangesAsync();
            return movie;
        }

        //PUT
        public async Task<Movie?> UpdateMovieAsync(string id, Movie movie)
        {
            var m = await _context.Movie.FirstOrDefaultAsync(x => x.MovieId == id);
            if (m == null) return m;
            m.MovieName = movie.MovieName;
            m.DirectorName = movie.DirectorName;
            m.Duration = movie.Duration;
            m.Genre = movie.Genre;
            m.Language = movie.Language;
            m.Story = movie.Story;
            m.ProducerName = movie.ProducerName;

            await _context.SaveChangesAsync();
            return m;
        }

        //Delete
        public async Task<Movie?> DeleteMovieAsync(string id)
        {
            var movie = await _context.Movie.FirstOrDefaultAsync(x => x.MovieId == id);
            if (movie == null) return movie;
            _context.Movie.Remove(movie);
            _context.SaveChanges();
            return movie;
        }

        
    }
}