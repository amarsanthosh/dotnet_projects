using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTicketBooking
{
    public class InvalidLanguageException : Exception 
    {
        public InvalidLanguageException() : base($"The mentioned language is invalid. Please ensure to enter a valid language")
        {
            
        }
    }
}