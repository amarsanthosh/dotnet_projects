using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class MovieDataStore
    {
        public List<Movie> Movies { get; set; } = new List<Movie>();
        public List<Show> Shows { get; set; } = new List<Show>();
        public List<Theatre> Theatres { get; set; } = new List<Theatre>();
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public List<LoginDetails> Logins { get; set; } = new List<LoginDetails>();
        public List<Booking> Bookings { get; set; } = new List<Booking>();
    }
}