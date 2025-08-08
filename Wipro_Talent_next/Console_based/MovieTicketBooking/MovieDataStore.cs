using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTicketBooking
{
    public class MovieDataStore
    {
        public List<Movie> Movies { get; set; } = new List<Movie>();
        public List<Show> Shows { get; set; } = new List<Show>();
        public List<Theatre> Theatres { get; set; } = new List<Theatre>();
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public List<LoginDetails> Logins { get; set; } = new List<LoginDetails>();
        public List<Booking> Bookings { get; set; } = new List<Booking>();

        public void FetchMovies()
        {
            var lines = File.ReadAllLines("Movies.csv");
            foreach (var line in lines)
            {
                var value = line.Split(" , ");
                var movie = new Movie(
                         value[1], value[2], value[3], double.Parse(value[4]), value[5], value[6], value[7]
                );
                Movies.Add(movie);
            }
        }
        public void FetchTheatres()
        {
            var lines = File.ReadAllLines("Theatres.csv");
            foreach (var line in lines)
            {
                var value = line.Split(" , ");
                var Theatre = new Theatre(
                         value[1], int.Parse(value[2]) // value[3], double.Parse(value[4]), value[5], value[6], value[7]
                );
                Theatres.Add(Theatre);
            }
        }
        public void FetchCustomers()
        {
            var lines = File.ReadAllLines("Customers.csv");
            foreach (var line in lines)
            {
                var value = line.Split(" , ");
                var Customer = new Customer(
                         value[1], value[2] // value[3], double.Parse(value[4]), value[5], value[6], value[7]
                );
                Customers.Add(Customer);
            }
        }
        public void FetchLogins()
        {
            var lines = File.ReadAllLines("Login.csv");
            foreach (var line in lines)
            {
                var value = line.Split(" , ");
                var Login = new LoginDetails(
                         value[1], value[2], value[3]// double.Parse(value[4]), value[5], value[6], value[7]
                );
                Logins.Add(Login);
            }
        }
        public void FetchShows()
        {
            var lines = File.ReadAllLines("Shows.csv");
            foreach (var line in lines)
            {
                var value = line.Split(" , ");
                var Show = new Show(
                         int.Parse(value[1]), int.Parse(value[2]), DateTime.Parse(value[3]), DateTime.Parse(value[4]), decimal.Parse(value[5]), decimal.Parse(value[6]), decimal.Parse(value[7])  // value[3], double.Parse(value[4]), value[5], value[6], value[7]
                );
                Shows.Add(Show);
            }
        }
        public void FetchBookings()
        {
            var lines = File.ReadAllLines("Booking.csv");
            foreach (var line in lines)
            {
                var value = line.Split(" , ");
                var Booking = new Booking(
                         int.Parse(value[1]), value[2], int.Parse(value[3]), value[4], value[5] // value[3], double.Parse(value[4]), value[5], value[6], value[7]
                );
                Bookings.Add(Booking);
            }
        }

        public MovieDataStore()
        {
            FetchMovies();
            FetchBookings();
            FetchCustomers();
            FetchLogins();
            FetchShows();
            FetchTheatres();
        }

        public void AddMovie(Movie movie)
        {
            if (movie == null) throw new NullReferenceException();
            Movies.Add(movie);
        }
        public void AddShow(Show Show)
        {
            if (Show == null) throw new NullReferenceException();
            Shows.Add(Show);
        }
        public void AddTheatre(Theatre theatre)
        {
            if (theatre == null) throw new NullReferenceException();
            Theatres.Add(theatre);
        }
        public void AddCustomer(Customer customer)
        {
            if (customer == null) throw new NullReferenceException();
            Customers.Add(customer);
        }
        public void AddLogin(LoginDetails login)
        {
            if (login == null) throw new NullReferenceException();
            Logins.Add(login);
        }         
        public void AddBooking(Booking booking)
        {
            if (booking == null) throw new NullReferenceException();
            Bookings.Add(booking);
        }          
    }
}