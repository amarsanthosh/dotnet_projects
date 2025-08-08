using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public DateTime BookingDate { get; set; }
        public int ShowId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public int NumberOfSeats { get; set; }
        public string SeatType { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Email { get; set; } = string.Empty;
        public string BookingStatus { get; set; } = string.Empty;
        public List<int> SeatNumbers { get; set; } = new List<int>();
    }
}