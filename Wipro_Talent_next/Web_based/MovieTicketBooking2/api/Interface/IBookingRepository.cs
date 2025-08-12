using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interface
{
    public interface IBookingRepository
    {
        Task<List<Booking>> GetAllBookingsAsync();


        Task<Booking?> GetBookingByIdAsync(int id);
        Task<Booking?> CreateBookingAsync(Booking booking);
        Task<Booking?> UpdateBookingAsync(int id, Booking booking);
        Task<Booking?> DeleteBookingAsync(int id);
    }
}