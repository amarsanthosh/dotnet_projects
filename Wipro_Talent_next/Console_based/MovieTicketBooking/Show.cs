using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace MovieTicketBooking
{
    public class Show
    {
        public int ShowId { get; set; }
        public int MovieId { get; set; }
        public int TheatreId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal PlatinumSeatRate { get; set; }
        public decimal SilverSeatRate { get; set; }
        public decimal GoldSeatRate { get; set; }
        public static int Id = 1;
        public Show(int MovieId, int TheatreId, DateTime StartDate, DateTime EndDate, decimal PlatinumSeatRate, decimal SilverSeatRate, decimal GoldSeatRate)
        {
            this.MovieId = MovieId;
            this.TheatreId = TheatreId;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.PlatinumSeatRate = PlatinumSeatRate;
            this.SilverSeatRate = SilverSeatRate;
            this.GoldSeatRate = GoldSeatRate;
            this.ShowId = Id++; 
        }
    }
}