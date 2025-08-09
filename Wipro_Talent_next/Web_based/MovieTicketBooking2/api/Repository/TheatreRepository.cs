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
    public class TheatreRepository : ITheatreRepository
    {

        private readonly ApplicationDbContext _context;

        public TheatreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get all theatres
        public async Task<List<Theatre>> GetAllTheatresAsync()
        {
            return await _context.Theatre.ToListAsync();
        }

        // Get theatre by id
        public async Task<Theatre?> GetTheatreByIdAsync(int id)
        {
            return await _context.Theatre.FirstOrDefaultAsync(x => x.TheatreId == id);
        }

        // Post
        public async Task<Theatre?> CreateTheatreAsync(Theatre theatre)
        {
            await _context.Theatre.AddAsync(theatre);
            await _context.SaveChangesAsync();
            return theatre;
        }

        // PUT
        public async Task<Theatre?> UpdateTheatreAsync(int id, Theatre theatre)
        {
            var existingTheatre = await _context.Theatre.FirstOrDefaultAsync(x => x.TheatreId == id);
            if (existingTheatre == null) return null;

            existingTheatre.TheatreName = theatre.TheatreName;
            existingTheatre.NumberOfSeats = theatre.NumberOfSeats;

            await _context.SaveChangesAsync();
            return existingTheatre;
        }

        // Delete
        public async Task<Theatre?> DeleteTheatreAsync(int id)
        {
            var theatre = await _context.Theatre.FirstOrDefaultAsync(x => x.TheatreId == id);
            if (theatre == null) return null;

            _context.Theatre.Remove(theatre);
            await _context.SaveChangesAsync();
            return theatre;
        }
    }
}