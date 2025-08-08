using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Theatre
    {
        public int TheatreId { get; set; }
        public string TheatreName { get; set; } = string.Empty;
        public int NumberOfSeats { get; set; }
    }
}