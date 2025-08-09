using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Booking;
using api.Interface;
using api.Mapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace api.Controller
{
    [ApiController]
    [Route("api/booking")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepositoy _bookingRepo;

        public BookingController(IBookingRepositoy bookingRepo)
        {
            _bookingRepo = bookingRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBookings()
        {
            var bookings = await _bookingRepo.GetAllBookingsAsync();
            Console.WriteLine("hhh" + bookings);

            return Ok(bookings);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] BookingCreateDto createDto)
        {
            var booking = createDto.ToBookingFromCreateDto();
            await _bookingRepo.CreateBookingAsync(booking);
            return Ok("Successfully Created");
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateBooking([FromRoute] int id, [FromBody] BookingCreateDto createDto)
        {
            var newbooking = createDto.ToBookingFromCreateDto();
            var result = await _bookingRepo.UpdateBookingAsync(id, newbooking);
            if (result == null) return BadRequest($"No product with id => {id}");
            return Ok("SuccessFully Updated");
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteBooking([FromRoute] int id)
        {
            var booking = await _bookingRepo.DeleteBookingAsync(id);
            if (booking == null) return BadRequest($"No product with id => {id}");
            return Ok("Successfully deleted");  
        }

    }
}