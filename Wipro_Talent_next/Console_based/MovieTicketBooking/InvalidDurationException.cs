using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTicketBooking
{
    public class InvalidDurationException : Exception
    {
        public InvalidDurationException() : base($"The mentioned movie duration is Invalid. Please ensure to enter a valid duration")
        {
            
        }
    }
}