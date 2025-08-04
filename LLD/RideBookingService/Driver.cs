using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RideBookingService
{
    public class Driver
    {
         public int Id { get; set; }
         public string Name { get; set; }
         public bool IsAvailable { get; set; } = true;
         public Location CurrentLocation { get; set; } = new Location(0, 0); // Default location

        public Driver(int id, string name, Location location)
        {
            this.CurrentLocation = location;
            this.Id = id;
            this.Name = name;
        }

        public void UpdateLocation(Location newLocation)
        {
            this.CurrentLocation = newLocation; 
        }

    }
}