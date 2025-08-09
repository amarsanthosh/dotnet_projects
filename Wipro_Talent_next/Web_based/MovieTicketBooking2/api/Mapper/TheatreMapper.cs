using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Theatre;
using api.Models;

namespace api.Mapper
{
    public static class TheatreMapper
    {
        public static Theatre ToTheatreFromCreateDto(this TheatreCreateDto theatreCreateDto)
        {
            return new Theatre
            {
                TheatreName = theatreCreateDto.TheatreName,
                NumberOfSeats = theatreCreateDto.NumberOfSeats
            };
        }
    }
}