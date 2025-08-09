using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Show;
using api.Models;

namespace api.Mapper
{
    public static class ShowMapper
    {
        public static Show ToShowFromCreateDto(this ShowCreateDto showCreateDto)
        {
            return new Show
            {
                StartDate = showCreateDto.StartDate,
                EndDate = showCreateDto.EndDate,
                MovieId = showCreateDto.MovieId,
                TheatreId = showCreateDto.TheatreId,
                PlatinumSeatRate = showCreateDto.PlatinumSeatRate,
                SilverSeatRate = showCreateDto.SilverSeatRate,
                GoldSeatRate = showCreateDto.GoldSeatRate
            };
        }
    }
}