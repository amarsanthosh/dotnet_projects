using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Booking;
using api.Models;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.VisualBasic;

namespace api.Mapper
{
    public static class BookingMapper
    {
        public static Booking ToBookingFromCreateDto(this BookingCreateDto bookingCreateDto)
        {
            return new Booking
            {
                BookingDate = bookingCreateDto.BookingDate,
                ShowId = bookingCreateDto.ShowId,
                CustomerName = bookingCreateDto.CustomerName,
                NumberOfSeats = bookingCreateDto.NumberOfSeats,
                SeatNumbers = bookingCreateDto.SeatNumbers,
                SeatType = bookingCreateDto.SeatType,
                Amount = bookingCreateDto.Amount,
                Email = bookingCreateDto.Email,
                BookingStatus = bookingCreateDto.BookingStatus
            };
        }
    }
}