using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Theatre;
using api.Interface;
using api.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace api.Controller
{
    [ApiController]
    [Route("api/theatre")]
    public class TheatreController : ControllerBase
    {
        private readonly ITheatreRepository _theatreRepo;

        public TheatreController(ITheatreRepository theatreRepo)
        {
            _theatreRepo = theatreRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTheatres()
        {
            var theatres = await _theatreRepo.GetAllTheatresAsync();
            return Ok(theatres);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetTheatreById(int id)
        {
            var theatre = await _theatreRepo.GetTheatreByIdAsync(id);
            if (theatre == null) return NotFound($"No theatre with id => {id}");
            return Ok(theatre);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTheatre([FromBody] TheatreCreateDto theatreCreateDto)
        {
            var theatre = theatreCreateDto.ToTheatreFromCreateDto();
            await _theatreRepo.CreateTheatreAsync(theatre);
            return Ok("Successfully Created");
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateTheatre([FromRoute] int id, [FromBody] TheatreCreateDto theatreCreateDto)
        {
            var theatre = theatreCreateDto.ToTheatreFromCreateDto();
            var updatedTheatre = await _theatreRepo.UpdateTheatreAsync(id, theatre);
            if (updatedTheatre == null) return NotFound($"No theatre with id => {id}");
            return Ok("Successfully Updated");
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteTheatre([FromRoute] int id)
        {
            var deletedTheatre = await _theatreRepo.DeleteTheatreAsync(id);
            if (deletedTheatre == null) return NotFound($"No theatre with id => {id}");
            return Ok("Successfully deleted");
        }

    }
}