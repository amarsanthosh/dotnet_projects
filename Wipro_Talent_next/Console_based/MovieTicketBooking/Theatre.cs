using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTicketBooking
{
    public class Theatre
    {
        public int TheatreId { get; set; }

        public string TheatreName { get; set; } = string.Empty;

        public int NumberOfSeats { get; set; }

        public Theatre(string TheatreName, int NumberOfSeats)
        {
            this.TheatreName = TheatreName;
            this.NumberOfSeats = NumberOfSeats;
        }

        public void DisplayTheatreDetails()
        {
            Console.WriteLine($"{TheatreId} - {TheatreName} - {NumberOfSeats}");
        }
    }
}