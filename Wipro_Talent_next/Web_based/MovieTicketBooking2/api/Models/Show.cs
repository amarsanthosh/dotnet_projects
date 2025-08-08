using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
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
    }
}