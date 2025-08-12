using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Movie;
using api.Interface;
using api.Mapper;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controller
{
    [ApiController]
    [Route("api/movie")]
    public class MovieController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        private readonly IMovieRepository _movieRepo;
        public MovieController(ApplicationDbContext context, IMovieRepository movieRepo)
        {
            _context = context;
            _movieRepo = movieRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
        {
            var movies = await _movieRepo.GetAllMoviesAsync();
            return Ok(movies);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var movie = await _movieRepo.GetMovieByIdAsync(id);
            if (movie == null) return NotFound($"No movie with id => {id}");
            return Ok(movie);
        }
        [HttpPost]
        public async Task<IActionResult> CreateMovie([FromBody] MovieCreateDto moviedto)
        {
            var movie = moviedto.ToMovieFromCreateDto();
            await _movieRepo.CreateMovieAsync(movie);
            return Ok("Successfully Created");
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateMovie([FromRoute] int id, [FromBody] MovieCreateDto moviedto)
        {
            var movie = moviedto.ToMovieFromCreateDto();
            var updatedMovie = await _movieRepo.UpdateMovieAsync(id, movie);
            if (updatedMovie == null) return NotFound($"No movie with id => {id}");
            return Ok("Successfully Updated");
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteMovie([FromRoute] int id)
        {
            var deletedMovie = await _movieRepo.DeleteMovieAsync(id);
            if (deletedMovie == null) return NotFound($"No movie with id => {id}");
            return Ok("Successfully deleted");
        }
    
    }
        
}
