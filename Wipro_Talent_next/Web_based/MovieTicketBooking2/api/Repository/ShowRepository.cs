using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interface;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ShowRepository : IShowRepository
    {
        private readonly ApplicationDbContext _context;

        public ShowRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //Get all shows
        public async Task<List<Show>> GetAllShowsAsync()
        {
            return await _context.Show.ToListAsync();
        }

        //Get show by id
        public async Task<Show?> GetShowByIdAsync(int id)
        {
            return await _context.Show.FirstOrDefaultAsync(x => x.ShowId == id);
        }

        //Post
        public async Task<Show?> CreateShowAsync(Show show)
        {
            await _context.Show.AddAsync(show);
            await _context.SaveChangesAsync();
            return show;
        }

        //PUT
        public async Task<Show?> UpdateShowAsync(int id, Show show)
        {
            var existingShow = await _context.Show.FirstOrDefaultAsync(x => x.ShowId == id);
            if (existingShow == null) return null;

            existingShow.StartDate = show.StartDate;
            existingShow.EndDate = show.EndDate;
            existingShow.MovieId = show.MovieId;
            existingShow.TheatreId = show.TheatreId;
            existingShow.PlatinumSeatRate = show.PlatinumSeatRate;
            existingShow.SilverSeatRate = show.SilverSeatRate;
            existingShow.GoldSeatRate = show.GoldSeatRate;

            await _context.SaveChangesAsync();
            return existingShow;
        }


        //Delete
        public async Task<Show?> DeleteShowAsync(int id)
        {
            var show = await _context.Show.FirstOrDefaultAsync(x => x.ShowId == id);
            if (show == null) return null;

            _context.Show.Remove(show);
            await _context.SaveChangesAsync();
            return show;
        }
    }
}