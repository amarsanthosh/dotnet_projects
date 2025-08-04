using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RideBookingService
{
    public class Location
    {

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Location(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public override string ToString()
        {
            return $"({Latitude}, {Longitude})";
        }   
        
    }
}