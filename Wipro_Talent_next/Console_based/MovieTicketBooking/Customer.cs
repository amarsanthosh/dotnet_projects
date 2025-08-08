using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTicketBooking
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public string CustomerName { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public Customer(string CustomerName, string City)
        {
            this.CustomerName = CustomerName;
            this.City = City;
        }

        public void DisplayCustomerDetails()
        {
            Console.WriteLine($"{CustomerId} - {CustomerName} - {City}");
        }
        
    }
}