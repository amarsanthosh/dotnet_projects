using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Show;
using api.Interface;
using api.Mapper;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controller
{
    [Route("api/show")]
    [ApiController]
    public class ShowController : ControllerBase
    {
        private readonly IShowRepository _showRepo;
        public ShowController(IShowRepository showRepo)
        {
            _showRepo = showRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllShows()
        {
            var shows = await _showRepo.GetAllShowsAsync();
            return Ok(shows);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetShowById(int id)
        {
            var show = await _showRepo.GetShowByIdAsync(id);
            if (show == null) return NotFound($"No show with id => {id}");
            return Ok(show);
        }
        [HttpPost]
        public async Task<IActionResult> CreateShow([FromBody] ShowCreateDto showdto)
        {
            var show = showdto.ToShowFromCreateDto();
            await _showRepo.CreateShowAsync(show);
            return Ok("Successfully Created");
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateShow([FromRoute] int id, [FromBody] ShowCreateDto showdto)
        {
            var show = showdto.ToShowFromCreateDto();
            var updatedShow = await _showRepo.UpdateShowAsync(id, show);
            if (updatedShow == null) return NotFound($"No show with id => {id}");
            return Ok("Successfully Updated");
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteShow([FromRoute] int id)
        {
            var deletedShow = await _showRepo.DeleteShowAsync(id);
            if (deletedShow == null) return NotFound($"No show with id => {id}");
            return Ok("Successfully deleted");
        }
        

    }
}