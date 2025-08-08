using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTicketBooking
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

        public static int Bid = 1;
        public int TheatreId { get; set; }

        public Booking(int ShowId, string CustomerName, int NumberOfSeats, string SeatType, string Email)
        {
            this.BookingId = Bid++;
            this.ShowId = ShowId;
            this.CustomerName = CustomerName;
            if (NumberOfSeats > 0 && NumberOfSeats < 5)
                this.NumberOfSeats = NumberOfSeats;
            else throw new InvalidDataException();

            this.SeatType = SeatType;
            this.Email = Email;
            BookingDate = DateTime.UtcNow;

            SeatPrice type = (SeatPrice)Enum.Parse(typeof(SeatPrice), SeatType);

            int price = (int)type;

            Amount = price * NumberOfSeats;
            // Show s; 
            // TheatreId = ;

            // SeatType;
        }

    }
}