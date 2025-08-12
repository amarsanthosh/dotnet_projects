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
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _context;
        public BookingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //Get all bookings
        public async Task<List<Booking>> GetAllBookingsAsync()
        {
            return await _context.Booking.ToListAsync();
        }
        //Get by id
        public async Task<Booking?> GetBookingByIdAsync(int id)
        {
            return await _context.Booking.FirstOrDefaultAsync(x => x.BookingId == id);
        }

        //Post
        public async Task<Booking?> CreateBookingAsync(Booking booking)
        {
            await _context.Booking.AddAsync(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

        //PUT
        public async Task<Booking?> UpdateBookingAsync(int id, Booking booking)
        {
            var existingBooking = await _context.Booking.FirstOrDefaultAsync(x => x.BookingId == id);
            if (existingBooking == null) return null;

            existingBooking.Amount = booking.Amount;
            existingBooking.ShowId = booking.ShowId;
            existingBooking.SeatNumbers = booking.SeatNumbers;
            existingBooking.CustomerName = booking.CustomerName;
            existingBooking.NumberOfSeats = booking.NumberOfSeats;
            existingBooking.SeatType = booking.SeatType;
            existingBooking.BookingDate = booking.BookingDate;
            existingBooking.Email = booking.Email;
            existingBooking.BookingStatus = booking.BookingStatus;

            await _context.SaveChangesAsync();
            return existingBooking;
        }

        //Delete
        public async Task<Booking?> DeleteBookingAsync(int id)
        {
            var booking = await _context.Booking.FirstOrDefaultAsync(x => x.BookingId == id);
            if (booking == null) return null;

            _context.Booking.Remove(booking);
            await _context.SaveChangesAsync();
            return booking;
        }
    }
}