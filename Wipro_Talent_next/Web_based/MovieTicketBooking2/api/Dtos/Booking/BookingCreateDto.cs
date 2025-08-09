using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Booking
{
    public class BookingCreateDto
    {
        [Required]
        public DateTime BookingDate { get; set; }
        [Required]
        public int ShowId { get; set; }
        [Required]
        public string CustomerName { get; set; } = string.Empty;
        [Required]
        public int NumberOfSeats { get; set; }
        [Required]
        public string SeatType { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string BookingStatus { get; set; } = string.Empty;
        [Required]
        public List<int> SeatNumbers { get; set; } = new List<int>();
    }
}