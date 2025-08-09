using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interface
{
    public interface ITheatreRepository
    {
        Task<List<Theatre>> GetAllTheatresAsync();
        Task<Theatre?> GetTheatreByIdAsync(int id);
        Task<Theatre?> CreateTheatreAsync(Theatre theatre);
        Task<Theatre?> UpdateTheatreAsync(int id, Theatre theatre);
        Task<Theatre?> DeleteTheatreAsync(int id);
    }
}