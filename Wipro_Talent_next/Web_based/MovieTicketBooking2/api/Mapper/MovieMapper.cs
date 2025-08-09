using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Movie;
using api.Models;

namespace api.Mapper
{
    public static class  MovieMapper
    {
        public static Movie ToMovieFromCreateDto(this MovieCreateDto movieCreateDto)
        {
            return new Movie
            {
                MovieName = movieCreateDto.MovieName,
                DirectorName = movieCreateDto.DirectorName,
                Duration = movieCreateDto.Duration,
                ProducerName = movieCreateDto.ProducerName,
                Story = movieCreateDto.Story,
                Genre = movieCreateDto.Genre,
                Language = movieCreateDto.Language
            };
        }
    }
}