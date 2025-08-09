using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interface
{
    public interface IShowRepository
    {
        Task<List<Show>> GetAllShowsAsync();
        Task<Show?> GetShowByIdAsync(int id);
        Task<Show?> CreateShowAsync(Show show);
        Task<Show?> UpdateShowAsync(int id, Show show);
        Task<Show?> DeleteShowAsync(int id);
    }
}